using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;
    [SerializeField] private int difficulty = 1;

    private int _currentHitPoints;
    private Enemy _enemy;

    private void OnEnable()
    {
        _currentHitPoints = maxHitPoints;
        _enemy = GetComponent<Enemy>();
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
            _enemy.RewardGold();
            maxHitPoints += difficulty;
            gameObject.SetActive(false);
        }
    }
}
