using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float spawnTimer = 1f;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private Bank bank;
    public int currentBankBalance { get { return bank.CurrentBalance; } }

    private Enemy[] pool;
    public List<Enemy> currentlyActiveEnemies { get { return ReturnActiveOnly(pool); } }
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
        pool = new Enemy[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemyPrefab, this.gameObject.transform);
            pool[i].gameObject.SetActive(false);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        foreach (Enemy enemy in pool)
        {
            enemy.gameObject.SetActive(true);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
    private List<Enemy> ReturnActiveOnly(Enemy[] inArray)
    {
        List<Enemy> output = new List<Enemy>();
        foreach (Enemy enemy in inArray)
        {
            if (enemy.gameObject.activeSelf == true)
            {
                output.Add(enemy);
            }
        }
        return output;
    }
}
