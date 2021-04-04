using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsController : MonoBehaviour
{

    [SerializeField] private Animator m_animator;

    [SerializeField] private Transform m_leader;

    [SerializeField] private float m_spaceBetween =  1.5f;

    public bool m_ShouldFollow;
    
    private void Update()
    {
        switch (m_ShouldFollow)
        {
            case true:
                switch (Vector3.Distance(m_leader.position, transform.position) >= m_spaceBetween)
                {
                    case true:
                        Vector3 direction = m_leader.position - transform.position;
                        transform.localPosition += direction * Time.deltaTime;
                        transform.LookAt(m_leader);
                        m_animator.SetBool("Run", true);
                        break;
                    case false:
                        m_animator.SetBool("Run", false);
                        break;
                }
                break;
            case false:
                break;
        }
    }

}
