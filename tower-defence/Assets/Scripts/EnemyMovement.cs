using UnityEngine;
using System.Collections.Generic; // lists
using System.Collections;
using System;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] [Range(0f, 1f)] private float travelPercent = 0f;

    private List<Node> path = new List<Node>();

    private Vector3 startPos;
    private Vector3 finalPos;

    private WaitForEndOfFrame _pathwaitTime;

    private Enemy _enemy;

    private GridManager _gridManager;
    private PathFinder _pathfinder;

    private void Awake()
    {
        _pathwaitTime = new WaitForEndOfFrame();
        _enemy = GetComponent<Enemy>();
        _gridManager = FindObjectOfType<GridManager>();
        _pathfinder = FindObjectOfType<PathFinder>();
    }

    private void OnEnable()
    {
        ReturnToStart();
        RecalculatePath();
        StartCoroutine(ProcessMovement());
    }

    private void ReturnToStart()
    {
        transform.position = _gridManager.GetPositionFromCoordinates(_pathfinder.StartingCoordinates);
    }

    private void FinishPath()
    {
        _enemy.StealGold();
        gameObject.SetActive(false);
    }
    private IEnumerator ProcessMovement()
    {
        for (int index = 1; index < path.Count; index++)
        {
            var wayPoint = path[index];
            startPos = transform.position;
            finalPos = _gridManager.GetPositionFromCoordinates(wayPoint.coordinates);
            travelPercent = 0f;

            transform.LookAt(finalPos);
            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, finalPos, travelPercent);
                yield return _pathwaitTime;
            }
        }
        FinishPath();
    }

    private void RecalculatePath()
    {
        path.Clear();

        path = _pathfinder.GetNewPath();
    }
}
