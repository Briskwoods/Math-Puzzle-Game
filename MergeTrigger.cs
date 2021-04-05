using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeTrigger : MonoBehaviour
{
    [SerializeField] private GameManager m_gameManager;

    private BoidsController[] AI;
    private AISeparator[] separators;
    

    private void OnTriggerEnter(Collider other)
    {
        switch (other.CompareTag("Player"))
        {
            case true:
                AI = FindObjectsOfType<BoidsController>();
                separators = FindObjectsOfType<AISeparator>();
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
}
