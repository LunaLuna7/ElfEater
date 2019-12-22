using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformDestroyer : MonoBehaviour
{
    [SerializeField]
    private LayerMask maskToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "1" || collision.gameObject.tag == "2" 
            || collision.gameObject.tag == "3" || collision.gameObject.tag == "4" ||
            collision.gameObject.tag == "5") 
        {
            Debug.Log("kys");
            Destroy(collision.gameObject);
        }
    }
}
