using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsTrigger : MonoBehaviour
{
    [SerializeField] private BoidsController m_AI;

    [SerializeField] private Animator m_boidsAnimator;

    [SerializeField] private bool b_canFollow;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.CompareTag("Player")) {
            case true:
                m_AI.m_ShouldFollow = b_canFollow;
                m_boidsAnimator.SetBool("Run",b_canFollow);
                break;
            case false:
                break;
        }
    }
}
