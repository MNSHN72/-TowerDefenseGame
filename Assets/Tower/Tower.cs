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
        turretHead.transform.LookAt(objectPool.Pool[0].transform);
    }

}
