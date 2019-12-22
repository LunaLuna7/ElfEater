using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() 
    {
        rb.velocity = new Vector3(0, -speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("player"))
        {
            Debug.Log("EndGame");
        }    
    }
}
