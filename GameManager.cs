using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI m_scoreText;

    [SerializeField] private MenuController m_menu;

    [SerializeField] private Transform m_player;
    [SerializeField] private Transform m_boss;
    
    [SerializeField] private Animator m_playerAnimator;
    [SerializeField] private Animator m_bossAnimator;

    [SerializeField] private int m_TargetTotal;

    [SerializeField] private GameObject m_playerPlaceholder;
    [SerializeField] private GameObject m_bossPlaceholder;

    [SerializeField] private GameObject m_score;
    [SerializeField] private GameObject m_target;


    public int m_currentTotal = 0;

    public float maxSize;
    public float growFactor;
    public float waitTime;

    private bool isFighting;



    // Start is called before the first frame update
    void Start()
    {
        Vibration.Init();
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        m_scoreText.text = m_currentTotal + "";
        m_score.transform.position = m_playerPlaceholder.transform.position;
        m_target.transform.position = m_bossPlaceholder.transform.position;

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
        Vibration.Vibrate(100);
    }


    private void Lose()
    {
        m_playerAnimator.SetBool("Fight", false);
        m_bossAnimator.SetBool("Fight", false);

        m_playerAnimator.SetTrigger("Lose");
        m_bossAnimator.SetBool("Win", true);

        m_menu.m_loseMenu.SetActive(true);
        Vibration.Vibrate(200);
    }

    public void TriggerFight()
    {
        m_score.SetActive(false);
        m_target.SetActive(false);
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
                Vibration.VibratePeek();
                yield return null;
            }
            // reset the timer
            

            yield return new WaitForSeconds(waitTime);

            timer = 0;
            while (1 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                Vibration.VibratePeek();
                yield return null;
            }

            timer = 0;
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator Fight()
    {
        isFighting = true;

        switch (m_currentTotal == m_TargetTotal){
            case true:
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1.2f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Hit");
                Vibration.VibratePeek();
                yield return new WaitForSeconds(1.2f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1.2f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Hit");
                Vibration.VibratePeek();
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1.2f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Hit");
                Vibration.VibratePeek();
                yield return new WaitForSeconds(1.2f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1.2f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Hit");
                Vibration.VibratePeek();
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
                Vibration.VibratePeek();
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Hit");
                Vibration.VibratePeek();
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Hit");
                Vibration.VibratePeek();
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_bossAnimator.SetTrigger("Fight");
                yield return new WaitForSeconds(1f);
                m_player.transform.LookAt(m_boss.position);
                m_boss.transform.LookAt(m_player.position);
                m_playerAnimator.SetTrigger("Hit");
                Vibration.VibratePeek();
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
    public int Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
