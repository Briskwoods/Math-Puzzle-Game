using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject m_mainMenu;
    public GameObject m_winMenu;
    public GameObject m_loseMenu;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        m_mainMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        m_winMenu.SetActive(false);
        m_mainMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        m_loseMenu.SetActive(false);
        Time.timeScale = 1f;
    }


    public void backToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        m_mainMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Loop()
    {
        SceneManager.LoadScene(1);
        m_winMenu.SetActive(false);
        m_mainMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
