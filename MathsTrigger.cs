using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathsTrigger : MonoBehaviour
{

    [SerializeField] private GameManager m_gameManger;
    [SerializeField] private TouchController m_player;

    [SerializeField] private int m_value;
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.CompareTag("Player") && m_player.m_movingForward)
        {
            case true:
                m_gameManger.Add(m_value);
                break;
            case false:
                break;
        }

        switch (other.CompareTag("Player") && m_player.m_movingBack)
        {
            case true:
                m_gameManger.Subtract(m_value);
                break;
            case false:
                break;
        }
    }
}
