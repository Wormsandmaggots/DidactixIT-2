using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    private int score;

    public void AddScore(int value)
    {
        score += value;
        UIManager.instance.UpdateScore(score);
    }
}
