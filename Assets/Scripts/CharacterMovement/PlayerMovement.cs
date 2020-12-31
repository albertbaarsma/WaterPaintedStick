using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 1f;
    public float fallMuliplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool isGrounded = true;
    public float jumpVelocity = 5f;

    public bool playerTouchesDoor = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Jump();
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
/*
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            rb.velocity = Vector2.right * speed;
        }
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            rb.velocity = Vector2.left * speed;
        }*/


        // better jump
        

        transform.position += moveInput * Time.fixedDeltaTime * speed;
    }

    void Jump()
    {

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }
}
