using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movingSpeed;
    private Rigidbody2D rb = new Rigidbody2D();
    [SerializeField] private float jumpPower;
    private bool canJump = true;
    private BoxCollider2D collider = new BoxCollider2D();
    private Animator animation = new Animator();

    public bool CanJump
    {
        set => canJump = value;
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animation = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (x == 1 || x == -1)
        {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x) * x, transform.localScale.y, transform.localScale.z);
        }

        if (x == 0)
        {
            animation.SetTrigger("Idle");    
        }
        else
        {
            animation.SetTrigger("Move");
        }
        
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
        if (col.gameObject.CompareTag("Wall"))
        {
            Physics2D.IgnoreCollision(col.collider,collider);
        }
    }
}
