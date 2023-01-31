using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    bool ground = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    void FixedUpdate()
    {

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y) * speed;
        //if (rb.velocity.x > 0)
        //{
        //    transform.localScale = new Vector3(0.5520272f, 0.5600321f, 1);
        //}
        //if (rb.velocity.x < 0)
        //{
        //    transform.localScale = new Vector3(-0.5520272f, 0.5600321f, 1);
        //}
    }
}
