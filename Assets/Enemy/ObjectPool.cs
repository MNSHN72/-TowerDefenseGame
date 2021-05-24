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
    public List<EnemyMovement> currentlyActiveEnemies { get { return ReturnActiveOnly(pool); } }
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
            pool[i] = Instantiate(enemyPrefab, this.gameObject.transform);
            pool[i].gameObject.SetActive(false);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        foreach (EnemyMovement enemy in pool)
        {
            enemy.gameObject.SetActive(true);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
    private List<EnemyMovement> ReturnActiveOnly(EnemyMovement[] inArray)
    {
        List<EnemyMovement> output = new List<EnemyMovement>();
        foreach (EnemyMovement enemy in inArray)
        {
            if (enemy.gameObject.activeSelf == true)
            {
                output.Add(enemy);
            }
        }
        return output;
    }
}
