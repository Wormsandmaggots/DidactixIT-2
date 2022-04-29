using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Interactable
{
    private void Start()
    {
        StartCoroutine(Waiter());
    }

    private void Update()
    {
        
    }

    private IEnumerator Waiter()
    {
        yield return new WaitForSeconds(2);
    }
}
