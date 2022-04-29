using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection
{
    Left = -1,
    Right = 1
}

public class EnemyBehaviour : Interactable
{
    [SerializeField] private int coinAmountDrop;
    
    private EnemySpawner spawner;
    
    [SerializeField] private MovementDirection direction;
    private Animator animation;
    public int CoinAmountDrop => coinAmountDrop;
    public MovementDirection Direction
    {
        set => direction = value;
    }
    
    public EnemySpawner Spawner
    {
        set => spawner = value;
    }

    private void Start()
    {
        transform.localScale = new Vector3(Convert.ToInt32(direction) * transform.localScale.x,
            transform.localScale.y,transform.localScale.z);
        canInteract = true;

        animation = GetComponent<Animator>();
    }

    void Update()
    {
        if (canInteract)
        {
            Movement();
            animation.SetTrigger("Move");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("BlockEverything"))
        {
            if (direction == MovementDirection.Left)
            { 
                direction = MovementDirection.Right;
            }
            else
            { 
                direction = MovementDirection.Left;
            }
            
            transform.localScale = new Vector3(Convert.ToInt32(direction) * Math.Abs(transform.localScale.x),
                transform.localScale.y,transform.localScale.z);

        }
            
        if (col.gameObject.CompareTag("Player"))
        { 
            CollisionWithPlayerAction();
        }

        if (col.gameObject.CompareTag("Coin"))
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(),col.collider);
        }
    }

    private void Movement()
    {
        transform.Translate(new Vector3(Convert.ToInt32(direction) * Time.deltaTime,0));
    }

    public override void CollisionWithPlayerAction()
    {
        CoinManager.instance.GenerateCoins(coinAmountDrop,transform.position);
        
        GetComponent<Rigidbody2D>().simulated = false;
        canInteract = false;
        
        spawner.StartCoroutine(spawner.SpawnEnemy());
        
        animation.SetTrigger("Die");
        Destroy(gameObject,2);
    }
}
