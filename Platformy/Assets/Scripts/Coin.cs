using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Interactable
{
    private CircleCollider2D collider = new CircleCollider2D();
    private void Start()
    {
        StartCoroutine(Waiter());
        collider = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canInteract)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                CollisionWithPlayerAction();
            }
            
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Coin"))
            {
                Physics2D.IgnoreCollision(collision.collider,collider);
            }
        }
    }

    public override void CollisionWithPlayerAction()
    {
        GameManager.instance.AddScore(1);
        Destroy(gameObject);
    }

    private IEnumerator Waiter()
    {
        yield return new WaitForSeconds(0.7f);
        canInteract = true;
    }
}
