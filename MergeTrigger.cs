using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeTrigger : MonoBehaviour
{
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
                    foreach (AISeparator sep in separators)
                    {
                        sep.m_spaceBetween = 0;
                    }
                    ai.m_spaceBetween = 0;
                    ai.Invoke("Merge", 2f);
                }
                break;
            case false:
                break;
        }
    }
}
