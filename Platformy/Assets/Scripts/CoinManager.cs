using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [SerializeField] private GameObject coin;

    public void GenerateCoins(int amount, Vector3 position)
    {
        for (int i = 0; i < amount; i++)
        {
            Rigidbody2D rb = Instantiate(coin, position, quaternion.identity).GetComponent<Rigidbody2D>();

            rb.velocity = new Vector2(Random.value, Random.value);
        }
    }
}
