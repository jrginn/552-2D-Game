using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public AudioSource SFXHealthPlayer;
    public AudioClip pumpkinThud;
    public GameObject SFX;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        //SFX.GetComponent<AudioSource>().Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Hurt()
    {
        //SFX.GetComponent<SoundManager>().playThud();
        health--;
        if(health <= 0)
        {
            Destroy(gameObject);
            if (gameObject.tag.Equals("Pumpkin"))
            {
                Vector2 pos = new(gameObject.transform.position.x, gameObject.transform.position.y);
                SpawnManager sm = FindObjectOfType<SpawnManager>();
                sm.UpdatePumpkinStatus(pos, false);
            }
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
