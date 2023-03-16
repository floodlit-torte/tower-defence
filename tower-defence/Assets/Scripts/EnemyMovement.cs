using UnityEngine;
using System.Collections.Generic; // lists
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<WayPoint> wayPoints = new List<WayPoint>();
    [SerializeField] private float cellPerSecond = 1f;

    private WaitForSecondsRealtime _pathWaitTime;

    private void Start()
    {
        _pathWaitTime = new WaitForSecondsRealtime(cellPerSecond);
        StartCoroutine(ProcessMovement());
    }

    private IEnumerator ProcessMovement()
    {
        foreach (var wayPoint in wayPoints)
        {
            transform.position = wayPoint.transform.position;
            yield return _pathWaitTime;
        }
    }
}
