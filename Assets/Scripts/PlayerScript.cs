using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public Transform planetPivot;
    bool ground = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        OnPlanetMovement();
        //OnRootMovement();
    }

    private void OnPlanetMovement()
    {
        planetPivot.Rotate(new Vector3(0, 0, -Input.GetAxisRaw("Horizontal")));
    }

    private void OnRootMovement()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y) * speed;
    }
}
