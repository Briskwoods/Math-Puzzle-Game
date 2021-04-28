using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovementTrigger : MonoBehaviour
{
    [SerializeField] private TouchController m_player;

    [SerializeField] private bool b_isFromLeft;
    [SerializeField] private bool b_isFromRight;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.CompareTag("Player"))
        {
            case true:
                m_player.isFromLeft = b_isFromLeft;
                m_player.isFromRight = b_isFromRight;
                break;
            case false:
                break;
        }
    }
}
