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

    [SerializeField] Image FadeImage;
    bool loadFinish = false;
    public bool pauseInput = false;

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
        //TitleCanvas.gameObject.SetActive(true);
    }

    public void CreditScreen()
    {
        CreditCanvas.gameObject.SetActive(true);
        //TitleCanvas.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        StartCoroutine(LoadingScene(GameScene));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadingScene(string scene)
    {
        yield return StartCoroutine(FadeIn());
        SceneManager.LoadScene(scene);
    }

    IEnumerator FadeIn()
    {
        Color change = FadeImage.color;
        pauseInput = true;
        yield return new WaitForSecondsRealtime(1);
        while (FadeImage.color.a < 1 && loadFinish == false)
        {
            change.a += Time.deltaTime;
            FadeImage.color = change;

            yield return null;
            if (FadeImage.color.a >= 1)
            {
                loadFinish = true;
                from.GetComponent<Canvas>().enabled = false;
            }
        }
        while (loadFinish && FadeImage.color.a >= 0)
        {
            change.a -= Time.deltaTime;
            FadeImage.color = change;
            yield return null;
            to.GetComponent<Canvas>().enabled = true;
            if (FadeImage.color.a <= 0)
            {
                loadFinish = false;
                pauseInput = false;
            }
        }

    }
}