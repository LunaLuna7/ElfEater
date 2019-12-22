using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    [SerializeField]
    int point = 100;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().Dash();
            GameManager.instance.IncrementScore(point);

            Destroy(this.gameObject);
        }    
    }
}
