using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isAvailable = true;
    [SerializeField] private Tower TowerPrefab;
    private void OnMouseDown()
    {
        if (isAvailable == true)
        {
            Instantiate(TowerPrefab, this.transform.position, Quaternion.identity);
            isAvailable = false;
        }
    }
}
