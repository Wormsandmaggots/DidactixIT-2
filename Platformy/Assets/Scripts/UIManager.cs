using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        scoreText.text = "0";
    }

    [SerializeField] private Text scoreText;
    [SerializeField] private Animator scoreAnimation;

    public void UpdateScore(int value)
    {
        scoreText.text = value.ToString();
        scoreAnimation.SetTrigger("GainPoint");
    }
}
