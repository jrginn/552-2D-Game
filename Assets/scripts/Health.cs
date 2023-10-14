using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public GameObject SFX;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        SFX = GameObject.FindGameObjectWithTag("SoundManager");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Hurt()
    {
        health--;
        if (gameObject.tag.Equals("Pumpkin")) {
            SFX.GetComponent<SoundManager>().playThud();
        }
        if(health <= 0)
        {
            if (gameObject.tag.Equals("Pumpkin"))
            {
                Vector2 pos = new(gameObject.transform.position.x, gameObject.transform.position.y);
                SpawnManager sm = FindObjectOfType<SpawnManager>();
                sm.UpdatePumpkinStatus(pos, false);
            }
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
