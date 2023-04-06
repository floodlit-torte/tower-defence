using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Node currentNode;

    private Vector2Int[] _directions = {Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left};

    private GridManager _gridManager;

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();
        if(_gridManager != null)
        {
            grid = _gridManager.Grid;
        }
    }

    private void Start()
    {
        ExploreNeighbors();
    }

    private void ExploreNeighbors()
    {
        if (grid.ContainsKey(currentNode.coordinates))
        {
            grid[currentNode.coordinates].isPath = true;
        }
        List<Node> neighbors = new List<Node>();
        foreach (Vector2Int direction in _directions)
        {
            Vector2Int neighborCoordinates = currentNode.coordinates + direction;
            if (grid.ContainsKey(neighborCoordinates))
            {
                neighbors.Add(grid[neighborCoordinates]);

                // TODO: Delete after debug
                grid[neighborCoordinates].isExplored = true;
                grid[currentNode.coordinates].isPath = true;
            }
        }
    }
}
