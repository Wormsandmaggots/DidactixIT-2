using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float delay;
    [SerializeField] private MovementDirection startDirection;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(delay);
        EnemyBehaviour enemy = Instantiate(enemyPrefab,transform.position,quaternion.identity,transform).GetComponent<EnemyBehaviour>();
        
        enemy.Spawner = this;
        enemy.Direction = startDirection;
    }
}
