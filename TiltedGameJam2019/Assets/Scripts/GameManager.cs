using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [Header("Inspector Header")]
    public bool gameIsOver;

    [SerializeField]
    GameObject gameOverPanel, pausePanel;

    [SerializeField]
    int score, highscore;

    [SerializeField]
    TextMeshProUGUI scoreUI, highscoreUI;

    void Awake()
    {
        if (instance == null)
            instance = this;

        gameIsOver = false;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscore = PlayerPrefs.GetInt("Highscore");
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        
        highscoreUI.SetText("Highscore:\n" + highscore);
    }

    private void Start()
    {
        gameIsOver = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        scoreUI.SetText("Score:\n" + score);
        if (score > highscore)
        {
            highscoreUI.SetText("Highscore:\n" + score);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (gameIsOver)
        {
            GameOver();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void IncrementScore(int addition)
    {
        score += addition;
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
        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }

        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}