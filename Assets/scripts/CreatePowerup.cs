using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePowerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Crow") || collision.gameObject.tag.Equals("Powerup"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        else if (collision.gameObject.tag.Equals("Projectile"))
        {
            SpawnManager sm = FindObjectOfType<SpawnManager>();
            print("before spwan");
            sm.SpawnRandomPumpkin();
        }
    }
}
