using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyPrefab;
    [SerializeField] private float spawnTimer = 1f;
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy() 
    {
        while (Application.isPlaying == true)
        {
            Instantiate(enemyPrefab, this.gameObject.transform);
            yield return new WaitForSeconds(spawnTimer); 
        }
    }
}
