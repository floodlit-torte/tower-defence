using UnityEngine;
using System.Collections.Generic; // lists
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<WayPoint> wayPoints = new List<WayPoint>();
    [SerializeField] private float speed = 2f;
    [SerializeField] [Range(0f, 1f)] private float travelPercent = 0f;

    private Vector3 startPos;
    private Vector3 finalPos;

    private WaitForEndOfFrame _pathwaitTime;
    private void Start()
    {
        _pathwaitTime = new WaitForEndOfFrame();
        StartCoroutine(ProcessMovement());
    }

    private IEnumerator ProcessMovement()
    {
        foreach (var wayPoint in wayPoints)
        {
            startPos = transform.position;
            finalPos = wayPoint.transform.position;
            travelPercent = 0f;
            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, finalPos, travelPercent);
                yield return _pathwaitTime;
            }
        }
    }
}
