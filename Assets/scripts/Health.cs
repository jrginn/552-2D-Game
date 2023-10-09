using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    private int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Hurt()
    {
        health--;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().Hurt();
        }
        gameObject.GetComponent<Health>().Hurt();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Pumpkin") && gameObject.tag.Equals("Crow"))
        {
            collision.gameObject.GetComponent<Health>().Hurt();
            gameObject.GetComponent<Health>().Hurt();
        }
    }
}
