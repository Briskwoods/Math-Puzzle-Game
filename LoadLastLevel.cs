using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLastLevel : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        switch (gameManager.Getint("Level")== 0)
        {
            case true:
                SceneManager.LoadScene(1);
                break;
            case false:
                SceneManager.LoadScene(gameManager.Getint("Level"));
                break;
        }

    }


}
