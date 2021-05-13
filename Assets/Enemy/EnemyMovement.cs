using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField] private float waitTime = 1f;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath()
    {
        foreach (Waypoint wp in path)
        {
            this.gameObject.transform.position = wp.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
