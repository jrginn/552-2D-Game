<<<<<<< HEAD:Assets/scripts/PlayerController.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    Rigidbody2D rb;
    Animator anim;
    public GameObject projectile;
    public float xbound = 9.0f;
    public float ypos = 4.47f;

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
        
        
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        anim.SetTrigger("Shoot");
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    Rigidbody2D rb;
    public GameObject projectile;
    public float xbound = 9.0f;
    public float ypos = 4.2f;
    public float shootDelayTime = 0.5f;

    public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if(Input.GetButtonDown("Fire1") && canShoot)
        {
            shoot();
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    void shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        //yield return new WaitForSeconds(2.5f);
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelayTime);
        canShoot = true;
    }
}
>>>>>>> b65d9b1caaf60bf8c8b523c8b77c826b0f64003e:Assets/scripts/PlayerScript.cs
