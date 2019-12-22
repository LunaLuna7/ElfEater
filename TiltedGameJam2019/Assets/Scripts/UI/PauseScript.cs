using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public Canvas PauseScreen;

    public Button PauseExit;
    public Button Title;

    private void Start()
    {
        Button TitleButton = Title.GetComponent<Button>();
        TitleButton.onClick.AddListener(ToTitle);
        Button PauseExitButton = PauseExit.GetComponent<Button>();
        PauseExitButton.onClick.AddListener(ExitPause);
    }


    void ToTitle()
    {
        StartCoroutine(LoadingScene());
    }

    void ExitPause()
    {
        Time.timeScale = 1f;
        PauseScreen.gameObject.SetActive(false);
    }

    IEnumerator LoadingScene()
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene("TitleScene");
    }
}
