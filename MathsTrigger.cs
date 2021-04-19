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
        Debug.Log("Called "+other.gameObject.name +" - "+ other.CompareTag("Player"));


        switch (other.CompareTag("Player") && m_player.m_movingForward && !m_player.m_movingLeft && !m_player.m_movingRight)
        {
            case true:
                m_gameManger.Add(m_value);
                m_player.m_movingForward = false;
                break;
            case false:
                break;

                return;
        }

        switch (other.CompareTag("Player") && m_player.m_movingBack && !m_player.m_movingLeft && !m_player.m_movingRight)
        {
            case true:
                m_gameManger.Subtract(m_value);
                m_player.m_movingBack = false;
                break;
            case false:
                break;

                return;
        }

        switch (other.CompareTag("Player") && m_player.isCentre && m_player.m_movingRight && !m_player.m_movingBack && !m_player.m_movingForward)
        {
            case true:
                m_gameManger.Add(m_value);
                m_player.m_movingRight = false;
                break;
            case false:
                break;

                return;
        }

        switch (other.CompareTag("Player") && m_player.isCentre && m_player.m_movingLeft && !m_player.m_movingBack && !m_player.m_movingForward)
        {
            case true:
                m_gameManger.Add(m_value);
                m_player.m_movingLeft = false;
                break;
            case false:
                break;

                return;
        }

        switch (other.CompareTag("Player") && m_player.isLeft && m_player.m_movingRight)
        {
            case true:
                m_gameManger.Subtract(m_value);
                m_player.m_movingRight = false;
                break;
            case false:
                break;

                return;
        }

        switch (other.CompareTag("Player") && m_player.isRight && m_player.m_movingLeft)
        {
            case true:
                m_gameManger.Subtract(m_value);
                m_player.m_movingLeft = false;
                break;
            case false:
                break;

                return;
        }
    }
}
