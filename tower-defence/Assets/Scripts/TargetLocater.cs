using System;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] private Transform TopMesh;
    [SerializeField] private float radius = 15f;
    [SerializeField] private ParticleSystem bolts;

    private Transform _target;

    private void Start()
    {
        _target = FindObjectOfType<EnemyMovement>().transform;
    }

    private void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(var enemy in enemies)
        {
            var targerDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (!(targerDistance < maxDistance))
                continue;
            closestTarget = enemy.transform;
            maxDistance = targerDistance;
        }

        _target = closestTarget;
    }

    private void AimWeapon()
    {
        TopMesh.LookAt(_target);
        var targerDistance = Vector3.Distance(transform.position, _target.position);
        Attack(targerDistance < radius);
    }

    private void Attack(bool state)
    {
        var boltsEmission = bolts.emission;
        boltsEmission.enabled = state;

    }
}
