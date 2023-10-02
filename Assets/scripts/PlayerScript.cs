using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.right * hori * moveSpeed * Time.deltaTime);
        Vector3 moveVect = rb.velocity;
        moveVect.x = hori * moveSpeed;
        moveVect.y = vert * moveSpeed;
        rb.velocity = moveVect;
    }
}
