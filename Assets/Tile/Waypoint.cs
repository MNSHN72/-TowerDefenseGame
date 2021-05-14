using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isAvailable = true;
    public bool IsAvailable { get { return isAvailable; } }

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
