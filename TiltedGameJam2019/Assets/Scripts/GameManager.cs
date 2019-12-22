using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    

    [Header("Inspector Header")]
        [SerializeField]
        bool gameIsOver;

        [SerializeField]
        GameObject gameOverPanel, pausePanel;

    void Awake()
    {
        if (instance == null)
            instance = this;
        
        gameIsOver = false; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (gameIsOver)
        {
            GameOver();
        }
    }

    private void TogglePause()
    {
        if (pausePanel.activeSelf) //if Game already is paused.
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
