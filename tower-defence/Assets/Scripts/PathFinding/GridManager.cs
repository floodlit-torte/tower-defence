using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Vector2Int gridSize;

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Start()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if(!grid.ContainsKey(coordinates))
            return null;
        return grid[coordinates];
    }

    private void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for(int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
                Debug.Log(grid[coordinates].coordinates + " " + grid[coordinates].isWalkable);
            }
        }
    }
}
