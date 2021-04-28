using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI m_Score;

    [SerializeField] private MenuController m_menu;

    [SerializeField] private Transform m_player;
    [SerializeField] private Transform m_boss;
    
    [SerializeField] private Animator m_playerAnimator;
    [SerializeField] private Animator m_bossAnimator;

    [SerializeField] private int m_TargetTotal;

    public int m_currentTotal = 0;

    public float maxSize;
    public float growFactor;
    public float waitTime;

    private bool isFighting;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_Score.text = m_currentTotal + "";
    }

    public void Merge()
    {
        m_playerAnimator.SetTrigger("Grow");
        StartCoroutine(Scale());      
    }

    public void Add(int numberToAdd)
    {
        //Debug.Log("Called Add");
        m_currentTotal += numberToAdd;
    }

    public void Subtract(int numberToSubtract)
    {
        //Debug.Log("Called Subtract");
        m_currentTotal -= numberToSubtract;
    }


    private void Win()
    {
        m_playerAnimator.SetBool("Fight", false);
        m_bossAnimator.SetBool("Fight", false);

        m_playerAnimator.SetBool("Win", true);
        m_bossAnimator.SetBool("Lose", true);

        m_menu.m_winMenu.SetActive(true);
    }


    private void Lose()
    {
        m_playerAnimator.SetBool("Fight", false);
        m_bossAnimator.SetBool("Fight", false);

        m_playerAnimator.SetTrigger("Lose");
        m_bossAnimator.SetBool("Win", true);


        m_menu.m_loseMenu.SetActive(true);
    }

    public void TriggerFight()
    {
        StartCoroutine(Fight());
    }

    IEnumerator Scale()
    {
        float timer = 0;


        while (true) // this could also be a condition indicating "alive or dead"
        {
            // we scale all axis, so they will have the same value, 
            // so we can work with a float instead of comparing vectors
            while (maxSize > m_player.transform.localScale.x)
            {
                timer += Time.deltaTime;
                m_player.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }
            // reset the timer
            

            yield return new WaitForSeconds(waitTime);

            timer = 0;
            while (1 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }

            timer = 0;
            yield return new WaitForSeconds(waitTime);
            //m_player.transform.LookAt(m_boss.position);
            //m_boss.transform.LookAt(m_player.position);
        }
    }

    IEnumerator Fight()
    {
        isFighting = true;
        
        switch(m_currentTotal == m_TargetTotal){
            case true:
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1.2f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Hit");
                yield return new WaitForSeconds(1.2f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1.2f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Hit");
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1.2f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Hit");
                yield return new WaitForSeconds(1.2f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1.2f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Hit");
                yield return new WaitForSeconds(1.2f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                isFighting = false;
                switch (!isFighting) {
                    case true:
                        Win();  
                        break;
                    case false:
                        break;
                }
                break;
            case false:
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Hit");
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Hit");
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Hit");
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Hit");
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                isFighting = false;
                switch (!isFighting)
                {
                    case true:
                        Lose();
                        break;
                    case false:
                        break;
                }
                break;
        }

    }
}
