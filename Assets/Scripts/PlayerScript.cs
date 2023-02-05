using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    public float rotationSpeed;
    public Transform planetPivot;
    public bool ground = true;
    public bool onRoot = false;
    public SpriteRenderer spr;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if(ground)OnPlanetMovement();
        if(onRoot) OnRootMovement();
        spr.flipX = Input.GetAxisRaw("Horizontal") > 0;
        
        if(ground && Input.GetAxisRaw("Horizontal") == 0) anim.SetTrigger("Idle");
        else if(ground && Input.GetAxisRaw("Horizontal") != 0) anim.SetTrigger("Walk");
        else if(!ground && onRoot && rb.velocity == Vector2.zero) anim.SetTrigger("IdleClimb");
        else if(onRoot && rb.velocity.y != 0) anim.SetTrigger("Climb");
    }

    private void OnPlanetMovement()
    {
        planetPivot.Rotate(new Vector3(0, 0, -Input.GetAxisRaw("Horizontal")) * rotationSpeed * Time.deltaTime);
    }

    private void OnRootMovement()
    {
        rb.velocity = new Vector2(ground?0:Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Planeta"))
        {
            ground = true;
            // Take the pivot from this planet and add it as a parent of the player
            // 1- Script in each planet that gives the pivot
            // 2- Set as parent
            transform.parent = planetPivot;
            // When doing the planet script use it to enable or disable colliders on the root
            transform.up = -(planetPivot.position - transform.position);
            transform.position += (planetPivot.position - transform.position).normalized * 0.1f;
        }
        else if(other.CompareTag("Root"))
        {
            onRoot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Planeta"))
        {
            ground = false;
            transform.parent = null;
            // Lerp rotate player
            transform.rotation = Quaternion.identity;
            transform.position += Vector3.up * 0.1f;
        }
        else if(other.CompareTag("Root"))
        {
            onRoot = false;
        }
    }

    public void Sonic()
    {
        moveSpeed *= 2;
    }
}
