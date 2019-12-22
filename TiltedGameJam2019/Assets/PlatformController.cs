using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    int weight, maxWeight = 10;

    [SerializeField]
    string color;

    void Awake()
    {
        SetColor();
        SetWeight();
    }

    void Update()
    {
        
    }

    private void SetColor()
    {
        string name = this.gameObject.name;
        print(name);
        if (name.Contains("p1"))
            color = "p1";
        else if (name.Contains("p2"))
            color = "p2";
        else
            color = "normal";

    }

    private void SetWeight()
    {
        //ChangeSprite
        TextMeshPro textWeight = this.GetComponentInChildren<TextMeshPro>();

        if (color == "normal")
        {
            textWeight.text = "";
        }
        else
        {
            weight = Random.Range(1, maxWeight + 1);
            textWeight.text = weight.ToString();

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedPlayer = collision.gameObject;
        PlayerMovement playerScript = collidedPlayer.GetComponent<PlayerMovement>();

        if ((color == "p1" && collidedPlayer.name == "Player1") || (color == "p2" && collidedPlayer.name == "Player2"))
        {
            if (playerScript.currentWeigth >= weight)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        GameObject collidedPlayer = other.gameObject;
        PlayerMovement playerScript = collidedPlayer.GetComponent<PlayerMovement>();

        if ((color == "p1" && collidedPlayer.name == "Player1") || (color == "p2" && collidedPlayer.name == "Player2"))
        {
            if (playerScript.currentWeigth >= weight)
            {
                Destroy(gameObject);
            }
        }
    }

}
