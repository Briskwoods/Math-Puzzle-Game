using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsController : MonoBehaviour
{

    [SerializeField] private Animator m_animator;

    [SerializeField] private Transform m_leader;

    [SerializeField] private GameManager m_gameManager;
    [SerializeField] private SkinnedMeshRenderer m_ragdoll;

    [SerializeField] private float m_maxSize = 1;
    [SerializeField] private float m_growthRate = 1.5f;

    [SerializeField] private Material m_normalColour;
    [SerializeField] private Material m_followColour;

    public float m_spaceBetween =  1.5f;

    public bool m_ShouldFollow;
    public bool m_mergeZone = false;

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
                m_ragdoll.material = m_followColour;
                break;
            case false:
                m_ragdoll.material = m_normalColour;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.collider.CompareTag("Player") && m_mergeZone)
        {
            case true:
                m_gameManager.maxSize += m_maxSize;
                m_gameManager.growFactor = m_growthRate;
                m_gameManager.Merge();
                Destroy(gameObject);
                break;
            case false:
                break;
        }
    }
}
