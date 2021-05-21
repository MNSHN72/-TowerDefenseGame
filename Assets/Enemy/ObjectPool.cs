using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private EnemyMovement Enemy;
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy() 
    {
        while (Application.isPlaying == true)
        {
            Instantiate(Enemy, this.gameObject.transform);
            yield return new WaitForSeconds(1f); 
        }
    }
}
