using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Button MainMenu;
    public Button Retry;

    void Start()
    {
        Button MainMenuButton = MainMenu.GetComponent<Button>();
        Button RetryButton = Retry.GetComponent<Button>();

        MainMenuButton.onClick.AddListener(GoHome);
        RetryButton.onClick.AddListener(ResetGame);
    }

    IEnumerator LoadingScene(string scene)
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene(scene);
    }

    public void ResetGame()
    {
        StartCoroutine(LoadingScene(SceneManager.GetActiveScene().name));
    }

    public void GoHome()
    {
        StartCoroutine(LoadingScene("TitleScene"));
    }
}
