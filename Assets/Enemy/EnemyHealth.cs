using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    [SerializeField] private int maxHp = 100;
    [SerializeField] private int currentHp;

    private Enemy enemy;

    private void OnEnable()
    {
        currentHp = maxHp;
    }
    private void Start()
    {
        enemy = this.gameObject.GetComponent<Enemy>();
    }
    private void OnParticleCollision(GameObject other)
    {
        currentHp -= 5;
        if (currentHp <= 0)
        {
            Kill();
            enemy.RewardGold();
        }
    }

    private void Kill()
    {
        this.gameObject.SetActive(false);
        this.gameObject.transform.position = gameObject.GetComponentInParent<Transform>().position;
    }
}
