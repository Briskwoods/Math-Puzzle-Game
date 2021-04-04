using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTrigger : MonoBehaviour
{
    [SerializeField] private TouchController m_player;

    [SerializeField] private bool b_canSwipeLeft;
    [SerializeField] private bool b_canSwipeRight;
    [SerializeField] private bool b_canSwipeUp;
    [SerializeField] private bool b_canSwipeDown;
    [SerializeField] private bool b_canSwipeTopRight;
    [SerializeField] private bool b_canSwipeBottomRight;
    [SerializeField] private bool b_canSwipeTopLeft;
    [SerializeField] private bool b_canSwipeBottomLeft;

    [SerializeField] private float b_moveDistance;



    private void OnTriggerEnter(Collider other)
    {
        switch(other.CompareTag("Player"))
        {
            case true:
                m_player.b_canSwipeLeft =  b_canSwipeLeft;
                m_player.b_canSwipeRight = b_canSwipeRight;
                m_player.b_canSwipeUp = b_canSwipeUp;
                m_player.b_canSwipeDown = b_canSwipeDown;
                m_player.b_canSwipeTopRight = b_canSwipeTopRight;
                m_player.b_canSwipeBottomRight = b_canSwipeBottomRight;
                m_player.b_canSwipeTopLeft = b_canSwipeTopLeft;
                m_player.b_canSwipeBottomLeft = b_canSwipeBottomLeft;

                m_player.m_moveDistanceMultiplier = b_moveDistance;

                break;
            case false:
                break;
        }
    }
}
