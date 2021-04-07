using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform m_player;

    [SerializeField] private Animator m_playerAnimator;
    [SerializeField] private Animator m_bossAnimator;

    [SerializeField] private int m_TargetTotal;

    public int m_currentTotal = 0;

    public float maxSize;
    public float growFactor;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Merge()
    {
        m_playerAnimator.SetTrigger("Grow");
        StartCoroutine(Scale());
        Invoke("Delay", 2f);
    }

    public void Add(int numberToAdd)
    {
        m_currentTotal += numberToAdd;
    }

    public void Subtract(int numberToSubtract)
    {
        m_currentTotal -= numberToSubtract;
    }


    private void Win()
    {
        m_playerAnimator.SetBool("Fight", false);
        m_bossAnimator.SetBool("Fight", false);

        m_playerAnimator.SetBool("Win", true);
        m_bossAnimator.SetBool("Lose", true);
    }


    private void Lose()
    {
        m_playerAnimator.SetBool("Fight", false);
        m_bossAnimator.SetBool("Fight", false);

        m_playerAnimator.SetBool("Lose", true);
        m_bossAnimator.SetBool("Win", true);
    }

    public void Fight()
    {
        m_playerAnimator.SetBool("Fight", true);
        m_bossAnimator.SetBool("Fight",true);
        Invoke("Delay", 2f);
        switch (m_currentTotal == m_TargetTotal)
        {
            case true:
                Win();
                break;
            case false:
                Lose();
                break;
        }
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
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
    }
}
