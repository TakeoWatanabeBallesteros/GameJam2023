using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    public float rotationSpeed;
    public float jumpForce;
    public Transform planetPivot;
    bool ground = true;
    private bool onRoot = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if(ground)OnPlanetMovement();
        if(onRoot) OnRootMovement();
    }

    private void OnPlanetMovement()
    {
        planetPivot.Rotate(new Vector3(0, 0, -Input.GetAxisRaw("Horizontal")) * rotationSpeed * Time.deltaTime);
    }

    private void OnRootMovement()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Planeta"))
        {
            ground = true;
            // Take the pivot from this planet and add it as a parent of the player
            // 1- Script in each planet that gives the pivot
            // 2- Set as parent
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
        }
        else if(other.CompareTag("Root"))
        {
            onRoot = true;
        }
    }
}
