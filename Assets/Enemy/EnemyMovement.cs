using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] private float speed = 1f;
    [SerializeField] private int maxHp = 100;
    private int currentHp;
    // Start is called before the first frame update
    private void Start()
    {
        currentHp = maxHp;
        StartCoroutine(FollowPath());
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
    }
    private void OnParticleCollision(GameObject other)
    {
        currentHp -= 5;
        if (currentHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
