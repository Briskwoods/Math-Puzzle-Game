using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMathTrigger : MonoBehaviour
{
    [SerializeField] private GameManager m_gameManger;
    [SerializeField] private TouchController m_player;

    [SerializeField] private int m_leftValue;
    [SerializeField] private int m_rightValue;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.CompareTag("Player") && m_player.isFromLeft && m_player.m_movingRight && !m_player.m_movingLeft && !m_player.isFromRight)
        {
            case true:
                m_gameManger.Add(m_rightValue);
                m_player.m_movingRight = false;
                break;
            case false:
                break;
        }


        switch (other.CompareTag("Player") && m_player.isFromLeft && m_player.m_movingLeft && !m_player.m_movingRight && !m_player.isFromRight)
        {
            case true:
                m_gameManger.Subtract(m_rightValue);
                m_player.m_movingLeft = false;
                break;
            case false:
                break;
        }

        switch (other.CompareTag("Player") && m_player.isFromRight && m_player.m_movingLeft && !m_player.m_movingRight && !m_player.isFromLeft)
        {
            case true:
                m_gameManger.Add(m_leftValue);
                m_player.m_movingRight = false;
                break;
            case false:
                break;
        }


        switch (other.CompareTag("Player") && m_player.isFromRight && m_player.m_movingRight && !m_player.m_movingLeft && !m_player.isFromLeft)
        {
            case true:
                m_gameManger.Subtract(m_leftValue);
                m_player.m_movingLeft = false;
                break;
            case false:
                break;
        }


    }
}
