using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform m_player;

    [SerializeField] private Animator m_playerAnimator;
    

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
}
