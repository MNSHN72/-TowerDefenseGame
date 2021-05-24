using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject turretHead;
    [SerializeField] private ObjectPool objectPool;

    private void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }
    private void Update()
    {
        turretHead.transform.LookAt(findTarget().transform);
    }
    private EnemyMovement findTarget() 
    {
        foreach (EnemyMovement enemy in objectPool.Pool)
        {
            if (enemy.gameObject.activeInHierarchy == true)
            {
                return enemy;
            }
        }
        return objectPool.Pool[0];
    }

}
