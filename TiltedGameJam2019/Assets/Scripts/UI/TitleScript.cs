using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public string GameScene;

    public Canvas CreditCanvas;
    public Canvas TitleCanvas;

    public Button Play;
    public Button Credit;
    public Button CreditClose;

    private void Start()
    {
        Button PlayButton = Play.GetComponent<Button>();
        Button CreditButton = Credit.GetComponent<Button>();
        Button Exit = CreditClose.GetComponent<Button>();

        PlayButton.onClick.AddListener(StartGame);
        CreditButton.onClick.AddListener(CreditScreen);
        Exit.onClick.AddListener(CloseCredit);
    }

    public void CloseCredit()
    {
        CreditCanvas.gameObject.SetActive(false);
        TitleCanvas.gameObject.SetActive(true);
    }

    public void CreditScreen()
    {
        CreditCanvas.gameObject.SetActive(true);
        TitleCanvas.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        StartCoroutine(LoadingScene(GameScene));
    }

    IEnumerator LoadingScene(string scene)
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene(scene);
    }
}