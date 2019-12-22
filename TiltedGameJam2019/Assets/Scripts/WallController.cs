using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = gameObject.transform.parent.Find("Players").gameObject;
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x, player.transform.position.y);
    }
}
