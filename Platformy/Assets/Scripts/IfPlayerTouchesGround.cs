using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfPlayerTouchesGround : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Wall"))
        {
            transform.GetComponentInParent<Player>().CanJump = true;
        }
    }
}
