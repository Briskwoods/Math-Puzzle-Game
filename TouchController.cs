using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Transform m_player;

    [SerializeField] private float m_moveSpeed = 3f;

    [SerializeField] private float m_moveDistanceMultiplier = 3f;

    [SerializeField] private Animator m_playerAnimator;

    [SerializeField] private Rigidbody m_rigidbody;
        
    public Vector3 m_desiredPosition;
    public Vector3 m_exactPosition;

    private bool m_tap;
    private bool m_swipeLeft;
    private bool m_swipeRight;
    private bool m_swipeUp;
    private bool m_swipeDown;
    private bool m_swipeTopRight;
    private bool m_swipeBottomRight;
    private bool m_swipeTopLeft;
    private bool m_swipeBottomLeft;
    private bool m_isDragging; 

    private Vector2 m_startTouch;
    private Vector2 m_swipeDelta;

    public Vector3 dir_sub;

    public float direction;
    // Update is called once per frame
    void Update()
    {
        m_tap = m_swipeLeft = m_swipeRight = m_swipeUp = m_swipeDown = m_swipeBottomLeft = m_swipeTopLeft = m_swipeBottomRight = m_swipeTopRight = false;

        
        direction = (Mathf.Atan2(m_swipeDelta.y, m_swipeDelta.x) / (Mathf.PI));
        
        #region 
        // PC Controls Test Code, uncoomment if you wish to Test with a mouse instead of Unity Remote 5

        //switch (Input.GetMouseButtonDown(0))
        //{
        //    case true:
        //        m_isDragging = true;
        //        m_tap = true;
        //        m_startTouch = Input.mousePosition;
        //        break;
        //    case false:
        //        break;
        //}

        //switch (Input.GetMouseButtonUp(0))
        //{
        //    case true:
        //        m_isDragging = false;
        //        Reset();
        //        break;
        //    case false:
        //        break;
        //}
        #endregion

        switch (Input.touches.Length > 0)
        {
            case true:
                switch (Input.touches[0].phase == TouchPhase.Began)
                {
                    case true:
                        m_isDragging = true;
                        m_tap = true;
                        m_startTouch = Input.touches[0].position;
                        break;
                    case false:
                        break;
                }
                switch(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    case true:
                        m_isDragging = false;
                        Reset();
                        break;
                    case false:
                        break;
                }
                break;
            case false:
                break;
        }

        // Calculate the distance
        m_swipeDelta = Vector2.zero;
        switch (m_isDragging)
        {
            case true:
                switch (Input.touches.Length > 0)
                {
                    case true:
                        m_swipeDelta = Input.touches[0].position - m_startTouch;
                        break;
                    case false:
                        break;
                }
                switch (Input.GetMouseButton(0))
                {
                    case true:
                        m_swipeDelta = (Vector2)Input.mousePosition - m_startTouch;
                        break;
                    case false:
                        break;
                }
                break;
            case false:
                break;
        }

        // Checking if deadzone was crossed.
        switch (m_swipeDelta.magnitude > 125)
        {
            //Detect direction


            case true:
                float x = m_swipeDelta.x;
                float y = m_swipeDelta.y;

                switch (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    case true:
                        // Left or right swipe
                        switch (x > 0 && direction > -0.125f && direction < 0.125f)
                        {
                            case true:
                                m_swipeRight = true;
                                break;
                            case false:
                                break;
                        }
                        switch (x < 0 && direction < -0.875f || direction > 0.875f)
                        {
                            case true:
                                m_swipeLeft = true;
                                break;
                            case false:
                                break;
                        }
                        break;
                    case false:
                        // Up or down swipe
                        switch (y > 0 && direction > 0.375f && direction < 0.625f)
                        {
                            case true:
                                m_swipeUp = true;
                                break;
                            case false:
                                break;
                        }

                        switch (y < 0 && direction < -0.375f && direction > -0.625f)
                        {
                            case true:
                                m_swipeDown = true;
                                break;
                            case false:
                                break;
                        }

                        // Top Right
                        switch (y > 0 && direction > 0.125f && direction < 0.375f)
                        {
                            case true:
                                m_swipeTopRight = true;
                                break;
                            case false:
                                break;
                        }

                        // Bottom Right
                        switch (y < 0 && direction < -0.125f && direction > -0.375f)
                        {
                            case true:
                                m_swipeBottomRight = true;
                                break;
                            case false:
                                break;
                        }

                        // Top Left
                        switch (y > 0 && direction > 0.625f && direction < 0.875f)
                        {
                            case true:
                                m_swipeTopLeft = true;
                                break;
                            case false:
                                break;
                        }

                        // Bottom Left
                        switch (y < 0 && direction < -0.625f && direction > -0.875f)
                        {
                            case true:
                                m_swipeBottomLeft = true;
                                break;
                            case false:
                                break;
                        }
                        break;
                }
                Reset();
                break;
            case false:
                break;
        }

        switch (m_swipeLeft)
        {
            case true:
                m_desiredPosition += Vector3.left;
                m_playerAnimator.SetTrigger("Run");
                Reset();
                break;
            case false:
                break;
        }
        switch (m_swipeRight)
        {
            case true:
                m_desiredPosition += Vector3.right;
                m_playerAnimator.SetTrigger("Run");
                break;
            case false:
                break;
        }
        switch (m_swipeUp)
        {
            case true:
                m_desiredPosition += Vector3.forward;
                m_playerAnimator.SetTrigger("Run");
                break;
            case false:
                break;
        }
        switch (m_swipeDown)
        {
            case true:
                m_desiredPosition += Vector3.back;
                m_playerAnimator.SetTrigger("Run");
                break;
            case false:
                break;
        }

        switch (m_swipeTopLeft)
        {
            case true:
                m_desiredPosition += Vector3.forward + Vector3.left;
                m_playerAnimator.SetTrigger("Run");
                break;
            case false:
                break;
        }

        switch (m_swipeTopRight)
        {
            case true:
                m_desiredPosition += Vector3.forward + Vector3.right;
                m_playerAnimator.SetTrigger("Run");
                break;
            case false:
                break;
        }

        switch (m_swipeBottomLeft)
        {
            case true:
                m_desiredPosition += Vector3.back + Vector3.left;
                m_playerAnimator.SetTrigger("Run");
                break;
            case false:
                break;
        }

        switch (m_swipeBottomRight)
        {
            case true:
                m_desiredPosition += Vector3.back + Vector3.right;
                m_playerAnimator.SetTrigger("Run");
                break;
            case false:
                break;
        }

        m_player.transform.position = Vector3.MoveTowards(m_player.position, m_desiredPosition * m_moveDistanceMultiplier, m_moveSpeed * Time.deltaTime);

        m_exactPosition = m_moveDistanceMultiplier * m_desiredPosition;

        m_player.LookAt(m_exactPosition);
   }

    private void Reset()
    {
        m_startTouch = m_swipeDelta = Vector2.zero;
        m_isDragging = false;
    }
}
