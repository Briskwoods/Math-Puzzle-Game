using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeTrigger : MonoBehaviour
{
    [SerializeField] private GameManager m_gameManager;

    [SerializeField] private BossController m_bossController;

    private BoidsController[] AI;
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.CompareTag("Player"))
        {
            case true:
                AI = FindObjectsOfType<BoidsController>();
                foreach(BoidsController ai in AI)
                {
                    ai.m_spaceBetween = 0;
                }
                break;
            case false:
                break;
        }

        switch (other.CompareTag("AI"))
        {
            case true:
                AI = FindObjectsOfType<BoidsController>();
                foreach (BoidsController ai in AI)
                {
                    ai.m_mergeZone = true;
                }
                break;
            case false:
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.CompareTag("Player"))
        {
            case true:
                AI = FindObjectsOfType<BoidsController>();

                int total = 0;

                foreach (BoidsController boid in AI) 
                {
                    if (boid.m_ShouldFollow) { total++; }
                }

                switch (total == 0 && !m_bossController.AlreadyCalled)
                {
                    case true:
                        m_bossController.TriggerEnemyMoveToPlayer();
                        break;
                    case false:
                        break;
                }
                break;
            case false:
                break;
        }
    }
}
