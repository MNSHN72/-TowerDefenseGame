using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject TurretHead;
    [SerializeField] private EnemyMovement Enemy;

    private void Start()
    {
        Enemy = FindObjectOfType<EnemyMovement>();
    }
    private void Update()
    {
        TurretHead.transform.LookAt(Enemy.transform);
    }

}
