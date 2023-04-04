using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int reward = 25;
    [SerializeField] private int penalty = 25;

    private Bank _bank;
    private void Start()
    {
        _bank = FindObjectOfType<Bank>();
    }
    public void RewardGold()
    {
        if (_bank == null) return;
        _bank.Deposite(reward);
    }
    public void StealGold()
    {
        if (_bank == null) return;
        _bank.WithDraw(penalty);
    }
}
