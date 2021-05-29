using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] private GameObject turretHead;
    [SerializeField] private ObjectPool objectPoolInScene;
    [SerializeField] private Enemy Target;
    [SerializeField] private ParticleSystem ProjectileParticles;
    [SerializeField] private float maxRange = 22f;

    private float maxDistance = float.PositiveInfinity;
    private float currentDistance;

    private void Start()
    {
        objectPoolInScene = FindObjectOfType<ObjectPool>();
    }
    private void Update()
    {
        FindTarget();
        Attack();
    }

    private void FindTarget()
    {
        List<Enemy> enemyList = objectPoolInScene.currentlyActiveEnemies;
        foreach (Enemy enemy in enemyList)
        {
            currentDistance = Vector3.Distance(this.gameObject.transform.position, enemy.transform.position);
            if (currentDistance <= maxDistance && enemy.gameObject.activeSelf == true)
            {
                Target = enemy;
                maxDistance = currentDistance;
            }
        }
    }
    private void Attack()
    {
        ToggleParticles(ProjectileParticles);
        AimWeapon();
    }
    private void ToggleParticles(ParticleSystem inPS)
    {
        var emissionModule = inPS.emission;
        if ((maxDistance <= maxRange) && (objectPoolInScene.currentlyActiveEnemies.Count > 0))
        {
            emissionModule.enabled = true;
        }
        else
        {
            emissionModule.enabled = false;
        }
    }

    private void AimWeapon()
    {
        if (objectPoolInScene.currentlyActiveEnemies.Count > 0 && Target.gameObject.activeSelf == true)
        {
            turretHead.transform.LookAt(Target.transform);
        }
        else if (Target.gameObject.activeSelf == false)
        {
            maxDistance = float.PositiveInfinity;
        }
    }
}
