using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    int weight, maxWeight = 10;

    [SerializeField]
    string color;

    void Awake()
    {
        weight = Random.Range(1, maxWeight+1);
        SetColor();
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

}
