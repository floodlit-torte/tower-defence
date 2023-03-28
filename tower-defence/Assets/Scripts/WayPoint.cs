using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private bool isPlaycable;
    [SerializeField] private GameObject Tower;
    private void OnMouseDown()
    {
        if (!isPlaycable)
            return;
        Instantiate(Tower, gameObject.transform.position, Quaternion.identity);
        isPlaycable = false;
    }
}
