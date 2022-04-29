using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movingSpeed;
    private Rigidbody2D rb;
    [SerializeField] private float jumpPower;
    private bool canJump = true;
    private BoxCollider2D collider;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        
        transform.Translate(new Vector3(x * movingSpeed * Time.deltaTime,0));
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && canJump)
        {
            rb.velocity = Vector2.up * jumpPower;
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("JumpReset"))
        {
            canJump = true;
        }

        if (col.gameObject.CompareTag("Wall"))
        {
            Physics2D.IgnoreCollision(col.collider,collider);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JumpReset"))
        {
            canJump = true;
        }
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            Physics2D.IgnoreCollision(collision.collider,collider);
        }
    }
}
