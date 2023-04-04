using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private Tower tower;
    [SerializeField] private bool isPlaycable;
    public bool IsPlaycable
    {
        get { return isPlaycable; }
    }
    private void OnMouseDown()
    {
        if (!isPlaycable)
            return;
        var isPlaced = tower.CreateTower(tower, transform.position);
        isPlaycable = !isPlaced;
    }
}
