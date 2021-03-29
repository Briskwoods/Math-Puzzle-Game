using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Transform m_player;
    
    [SerializeField] private float m_moveSpeed = 3f;
    
    private Vector3 m_desiredPosition;

    private bool m_tap;
    private bool m_swipeLeft;
    private bool m_swipeRight;
    private bool m_swipeUp;
    private bool m_swipeDown;
    private bool m_isDragging; 

    private Vector2 m_startTouch;
    private Vector2 m_swipeDelta;

    // Update is called once per frame
    void Update()
    {
        m_tap = m_swipeLeft = m_swipeRight = m_swipeUp = m_swipeDown = false;

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
            case true:
                float x = m_swipeDelta.x;
                float y = m_swipeDelta.y;

                switch (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    case true:
                        // Left or right swipe
                        switch (x < 0)
                        {
                            case true:
                                m_swipeLeft = true;
                                break;
                            case false:
                                m_swipeRight = true;
                                break;
                        }
                        break;
                    case false:
                        // Up or down swipe
                        switch (y < 0)
                        {
                            case true:
                                m_swipeDown = true;
                                break;
                            case false:
                                m_swipeUp = true;
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
                break;
            case false:
                break;
        }
        switch (m_swipeRight)
        {
            case true:
                m_desiredPosition += Vector3.right;
                break;
            case false:
                break;
        }
        switch (m_swipeUp)
        {
            case true:
                m_desiredPosition += Vector3.up;
                break;
            case false:
                break;
        }
        switch (m_swipeDown)
        {
            case true:
                m_desiredPosition += Vector3.down;
                break;
            case false:
                break;
        }

        m_player.transform.position = Vector3.MoveTowards(m_player.transform.position, m_desiredPosition, m_moveSpeed * Time.deltaTime);
    }

    private void Reset()
    {
        m_startTouch = m_swipeDelta = Vector2.zero; 
    }
}
