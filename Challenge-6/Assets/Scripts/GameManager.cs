using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    
    private Ground [] allGrounds;

    void Start()
    {
        SetupNewLevel();
    }

    private void SetupNewLevel()
    {
        allGrounds = FindObjectsOfType<Ground>();
    }

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }else if (singleton != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene , LoadSceneMode mode)
    {
        SetupNewLevel();
    }

    public void CheckComplete()
    {
        bool isFinished = true;

        for(int i = 0; i < allGrounds.Length; i++)
        {
            if (allGrounds[i].isColored == false)
            {
                isFinished = false;
                break;
            }
        }

        if (isFinished)
        {
            //NextLevel
        }
    }

    private void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
   
}
