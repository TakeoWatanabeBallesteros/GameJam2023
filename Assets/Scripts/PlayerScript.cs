using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    public float rotationSpeed;
    public Transform planetPivot;
    public bool onGround = true;
    public bool onRoot = false;
    public SpriteRenderer spr;
    public Animator anim;
    public Transform cam;

    public bool canTP;

    public Vector3 tpPos;

    public GameObject tp1;
    public GameObject tp2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        cam.position = new Vector3(transform.position.x, transform.position.y, cam.position.z);
        
        rb.velocity = Vector2.zero;
        if(onGround)OnPlanetMovement();
        if(onRoot || (!onRoot && !onGround)) OnRootMovement();
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            spr.flipX = Input.GetAxisRaw("Horizontal") > 0;
        }
        
        if((onGround || (!onGround && !onRoot)) && Input.GetAxisRaw("Horizontal") == 0) anim.SetTrigger("Idle");
        else if((onGround || (!onGround && !onRoot)) && Input.GetAxisRaw("Horizontal") != 0) anim.SetTrigger("Walk");
        else if(!onGround && onRoot && rb.velocity == Vector2.zero) anim.SetTrigger("IdleClimb");
        else if(onRoot && rb.velocity.y != 0) anim.SetTrigger("Climb");

        if (canTP && Input.GetKey(KeyCode.E))
        {
            
        }
    }

    private void OnPlanetMovement()
    {
        planetPivot.Rotate(new Vector3(0, 0, -Input.GetAxisRaw("Horizontal")) * rotationSpeed * Time.deltaTime);
    }

    private void OnRootMovement()
    {
        rb.velocity = new Vector2(onGround?0:Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Planeta"))
        {
            onGround = true;
            // Take the pivot from this planet and add it as a parent of the player
            // 1- Script in each planet that gives the pivot
            // 2- Set as parent
            planetPivot = other.GetComponent<PlanetaBehaviour>().planetPivot;
            other.GetComponent<PlanetaBehaviour>().UnblockLats();
            transform.parent = planetPivot;
            // When doing the planet script use it to enable or disable colliders on the root
            transform.up = -(planetPivot.position - transform.position);
            transform.position += (planetPivot.position - transform.position).normalized * 0.1f;
        }
        else if(other.CompareTag("Tp1"))
        {
            tpPos = tp2.transform.position;
            canTP = true;
        }
        else if(other.CompareTag("Tp2"))
        {
            tpPos = tp1.transform.position;
            canTP = true;
        }
        else if(other.CompareTag("Root"))
        {
            onRoot = true;
        }
        else if(other.CompareTag("GameEndTag"))
        {
            SceneManager.LoadScene("GameEndScene");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Planeta"))
        {
            other.GetComponent<PlanetaBehaviour>().BlockLats();
            onGround = false;
            transform.parent = null;
            // Lerp rotate player
            transform.rotation = Quaternion.identity;
            transform.position += Vector3.up * 0.1f;
        }
        else if(other.CompareTag("Tp1"))
        {
            canTP = false;
        }
        else if(other.CompareTag("Tp2"))
        {
            canTP = false;
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

    public void Guantes()
    {
        rotationSpeed *= 2;
    }

    public void Tipi()
    {
        tp1.SetActive(true);
        tp2.SetActive(true);
    }
}
