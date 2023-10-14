using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    Rigidbody2D rb;
    Animator anim;
    public GameObject projectile;
    public GameObject deathScreen; // Death screen to trigger
    public float deathAnimTime = 1.2f;
    public Vector3 projectileOffset = new Vector3(0.3f, 0, 0);
    public float shootDelayTime = 1f;
    public float xbound = 7.5f;
    public float ypos = 4.3f;
    public bool canShoot = true;

    public GameObject SFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * hori * moveSpeed * Time.deltaTime);
        Vector3 moveVect = rb.velocity;
        if (transform.position.x < -xbound) {
            moveVect.x = 0;
            transform.position = new Vector3(-xbound, ypos, 0);
        } else if (transform.position.x > xbound) {
            moveVect.x = 0;
            transform.position = new Vector3(xbound, ypos, 0);
        } else {
            moveVect.x = hori * moveSpeed;
        }

        rb.velocity = moveVect;
        
        // for animation
        if (hori > 0) {
            anim.SetBool("Walking", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (hori < 0) {
            anim.SetBool("Walking", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else {
            anim.SetBool("Walking", false);
        }
        
        
        if(!PauseBehavior.isPaused && Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(shoot());
        }
    }

    public IEnumerator DeathAnimation()
    {
        SFX.GetComponent<SoundManager>().playScarecrowDeath();
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(deathAnimTime);
        deathScreen.SendMessage("OnDeath");
    }

    IEnumerator shoot()
    {
        canShoot = false;
        Instantiate(projectile, transform.position + projectileOffset, Quaternion.identity);
        anim.SetTrigger("Shoot");
        SFX.GetComponent<SoundManager>().playShootSeed();
        yield return new WaitForSeconds(shootDelayTime);
        canShoot = true;
    }
    
}