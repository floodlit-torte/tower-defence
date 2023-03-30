using UnityEngine;
using System.Collections.Generic; // lists
using System.Collections;
using System;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<WayPoint> path = new List<WayPoint>();
    [SerializeField] private float speed = 2f;
    [SerializeField] [Range(0f, 1f)] private float travelPercent = 0f;

    private Vector3 startPos;
    private Vector3 finalPos;

    private WaitForEndOfFrame _pathwaitTime;
    private void Start()
    {
        _pathwaitTime = new WaitForEndOfFrame();
        FindPath();
        ReturnToStart();
        StartCoroutine(ProcessMovement());
    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    private IEnumerator ProcessMovement()
    {
        foreach (var wayPoint in path)
        {
            startPos = transform.position;
            finalPos = wayPoint.transform.position;
            travelPercent = 0f;

            transform.LookAt(finalPos);
            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, finalPos, travelPercent);
                yield return _pathwaitTime;
            }
        }
        Destroy(gameObject);
    }

    private void FindPath()
    {
        path.Clear();

        var wayPoints = GameObject.FindGameObjectsWithTag("Path");
        foreach (var wayPoint in wayPoints)
        {
            path.Add(wayPoint.GetComponent<WayPoint>());
        }
    }
}
