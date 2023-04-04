using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int cost = 75;

    public bool CreateTower(Tower tower, Vector3 position)
    {
        var bank = FindObjectOfType<Bank>();

        if (bank == null)
            return false;
        if(bank.curretnBalance < cost)
            return false;

        Instantiate(tower.gameObject, position, Quaternion.identity);
        bank.WithDraw(cost);
        return true;
    }
}
