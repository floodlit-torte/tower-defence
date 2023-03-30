using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;

    private int _currentHitPoints;

    private void Start()
    {
        _currentHitPoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProccesHit();
    }

    private void ProccesHit()
    {
        _currentHitPoints--;
        if (_currentHitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
