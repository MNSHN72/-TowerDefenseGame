using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isAvailable = true;
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private ObjectPool objectPoolInScene;
    public ObjectPool ObjectPoolInScene { get { return objectPoolInScene; } }
    public bool IsAvailable { get { return isAvailable; } }


    private void OnMouseDown()
    {
        if (isAvailable == true)
        {
            bool hasBeenPlaced = towerPrefab.InstantiateTower(towerPrefab, this.gameObject.transform.position);
            isAvailable = !hasBeenPlaced;
        }
    }
}
