using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Tower tower;
    [SerializeField] private bool isPlaycable;
    public bool IsPlaycable
    {
        get { return isPlaycable; }
    }

    private GridManager gridManager;
    private PathFinder pathFinder;
    private Vector2Int coordinates = new();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
    }

    private void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaycable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    private void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable)
        {
            bool isPlaced = tower.CreateTower(tower, transform.position);
            if (isPlaced)
            {
                gridManager.BlockNode(coordinates);
                pathFinder.GetNewPath();
            }
        }
    }
}
