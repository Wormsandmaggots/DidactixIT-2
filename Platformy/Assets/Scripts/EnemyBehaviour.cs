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

    public int CoinAmountDrop => coinAmountDrop;

    [SerializeField] private MovementDirection direction;

    public MovementDirection Direction
    {
        set => direction = value;
    }

    private EnemySpawner spawner;

    public EnemySpawner Spawner
    {
        set => spawner = value;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            if (direction == MovementDirection.Left)
            {
                direction = MovementDirection.Right;
            }
            else
            {
                direction = MovementDirection.Left;
            }
        }
    }

    private void Movement()
    {
        transform.Translate(new Vector3(Convert.ToInt32(direction) * Time.deltaTime,0));
    }

    public override void OnCollisionWithPlayerAction()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject,2);
    }

    private void OnDestroy()
    {
        spawner.StartCoroutine(spawner.SpawnEnemy());
    }
}
