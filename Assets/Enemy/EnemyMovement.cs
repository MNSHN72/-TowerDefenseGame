using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    // Start is called before the first frame update
    private void Start()
    {
        PrintWaypointNames();
        MoveAlongPath();
    }

    private void MoveAlongPath()
    {
        foreach (Waypoint wp in path)
        {
            Invoke(, 1f);
        }
    }

    private void MoveOneSpace()
    {
        this.gameObject.transform.position = wp.transform.position;
    }

    private void PrintWaypointNames()
    {
        foreach (Waypoint wp in path)
        {
            Debug.Log(wp.name);
        }
    }
}
