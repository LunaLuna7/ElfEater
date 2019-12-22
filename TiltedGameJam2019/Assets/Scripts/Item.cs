using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public Sprite icon;
    public int score;
    public virtual void effect() { }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameUI.Instance.ScoreUpdate(score);
            GameUI.Instance.ItemsUpdate();
            effect();
        }
        Destroy(this);
    }

}
