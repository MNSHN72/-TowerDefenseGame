using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyPrefab;
    [SerializeField] private float spawnTimer = 1f;
    [SerializeField] private int poolSize = 5;

    private EnemyMovement[] pool;
    public EnemyMovement[] Pool { get { return pool; } }
    private void Awake()
    {
        PopulatePool();
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        pool = new EnemyMovement[poolSize];

        for (int i = 0; i < 5; i++)
        {
            EnemyMovement spawnedEnemy = Instantiate(enemyPrefab, this.gameObject.transform);
            spawnedEnemy.gameObject.SetActive(false);
            pool[i] = spawnedEnemy;
        }
    }

    IEnumerator SpawnEnemy() 
    {
        while (Application.isPlaying == true)
        {
            foreach (EnemyMovement enemy in pool)
            {
                enemy.gameObject.SetActive(true);
                yield return new WaitForSeconds(spawnTimer);
            }
        }
    }
}
