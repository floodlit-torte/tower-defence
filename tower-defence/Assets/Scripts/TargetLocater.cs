using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] private GameObject TopMesh;

    private Transform _target;

    private void Start()
    {
        _target = FindObjectOfType<EnemyMovement>().transform;
    }

    private void Update()
    {
        TopMesh.transform.LookAt(_target);
    }
}
