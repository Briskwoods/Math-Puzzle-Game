using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossController : MonoBehaviour
{
    [SerializeField] private Animator m_animator;

    [SerializeField] private GameManager m_gameManager;

    [SerializeField] private Transform m_fightZone;


    public bool AlreadyCalled = false;

    public void TriggerEnemyMoveToPlayer() 
    {
        AlreadyCalled = true;
        m_animator.SetTrigger("Run");
        transform.DOMove(m_fightZone.position, 1f).OnComplete(StartFightNow);
    }

    public void StartFightNow() 
    {
        m_gameManager.TriggerFight();
    }
}
