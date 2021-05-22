using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject turretHead;
    [SerializeField] private EnemyMovement enemyPrefab;

    private void Start()
    {
        enemyPrefab = FindObjectOfType<EnemyMovement>();
    }
    private void Update()
    {
        turretHead.transform.LookAt(enemyPrefab.transform);
    }

}
