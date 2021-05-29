using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    [SerializeField] private int maxHp = 100;
    [SerializeField] private int currentHp;
    private void OnEnable()
    {
        currentHp = maxHp;
    }
    private void OnParticleCollision(GameObject other)
    {
        currentHp -= 5;
        if (currentHp <= 0)
        {
            KillThisEnemy();
        }
    }

    private void KillThisEnemy()
    {
        this.gameObject.SetActive(false);
        this.gameObject.transform.position = gameObject.GetComponentInParent<Transform>().position;
    }
}
