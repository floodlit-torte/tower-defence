using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Vector2Int startingCoordinates;
    [SerializeField] private Vector2Int endCoordinates;
    [SerializeField] private Node currentSearchNode;

    private Node _startingNode;
    private Node _endNode;
    private Dictionary<Vector2Int, Node> reached = new ();
    private Queue<Node> frontier = new();

    private Vector2Int[] _directions = {Vector2Int.right, Vector2Int.up, Vector2Int.down, Vector2Int.left};

    private GridManager _gridManager;

    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();
        if(_gridManager != null)
        {
            grid = _gridManager.Grid;
            _startingNode = grid[startingCoordinates];
            _endNode = grid[endCoordinates];
        }
    }

    private void Start()
    {
        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        _gridManager.ResetNodes();
        BreadthFirstSearch();
        return BuildPath();
    }

    private void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        foreach (Vector2Int direction in _directions)
        {
            Vector2Int neighborCoordinates = currentSearchNode.coordinates + direction;
            if (grid.ContainsKey(neighborCoordinates))
            {
                neighbors.Add(grid[neighborCoordinates]);
            }
        }

        foreach(var neighbor in neighbors)
        {
            if (!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                neighbor.connectedTo = currentSearchNode;
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    private void BreadthFirstSearch()
    {
        _startingNode.isWalkable = true;
        _endNode.isWalkable = true;

        frontier.Clear();
        reached.Clear();

        bool isRunning = true;
        frontier.Enqueue(_startingNode);
        reached.Add(startingCoordinates, _startingNode);

        while (frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if(currentSearchNode.coordinates == endCoordinates)
            {
                isRunning = false;
            }
        }
    }

    private List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();

        path.Add(_endNode);
        _endNode.isPath = true;

        Node currentNode = _endNode;
        while(currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }

        path.Reverse();
        return path;
    }
}
