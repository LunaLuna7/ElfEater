using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : Singleton<GameUI>
{
    private int totalScore = 0;
    private float time = 0;
    private int ItemsCollected = 0;

    public TextMeshProUGUI TotalScore;
    public TextMeshProUGUI Player1Weight;
    public TextMeshProUGUI Player2Weight;
    public TextMeshProUGUI ItemsCounter;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    private void WeightUpdate(int player, int weight)
    {
        if (player == 1)
        {
            Player1Weight.text = "" + weight;
        }
        else if (player == 2)
        {
            Player2Weight.text = "" + weight;
        }
    }

    public void ScoreUpdate(int score)
    {
        totalScore += score * 100 + (int)time * 10;
        TotalScore.text = "" + totalScore; // + score
    }

    public void ItemsUpdate()
    {
        ItemsCollected += 1;
        ItemsCounter.text = "" + ItemsCollected; // + score
    }

}
