using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] private float speed = 1f;
    //[SerializeField] private int maxHp = 100;
    //[SerializeField] private int currentHp;
    private void OnEnable()
    {
        //currentHp = maxHp;
        FindPath();
        StartCoroutine(FollowPath());
    }
    private void FindPath() 
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    private IEnumerator FollowPath()
    {
        foreach (Waypoint wp in path)
        {
            Vector3 startPosition = this.gameObject.transform.position;
            Vector3 endPosition = wp.transform.position;
            float travelPercent = 0f;

            this.gameObject.transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                this.gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        this.gameObject.SetActive(false);
        this.gameObject.transform.position = gameObject.GetComponentInParent<Transform>().position;
    }

}
