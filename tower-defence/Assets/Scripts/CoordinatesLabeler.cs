using UnityEngine;
using UnityEditor;
using TMPro;

[ExecuteAlways]
public class CoordinatesLabeler : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.black;
    [SerializeField] private Color exploredColor = Color.yellow;
    [SerializeField] private Color pathColor = new Color(1f, 0.5f, 0f);

    private TMP_Text _label;
    private Vector2Int _coordinates;
    private GridManager _gridManager;

    private void Awake()
    {
        pathColor = new Color(1f, 0.5f, 0f);
        _gridManager = FindObjectOfType<GridManager>();
        _label = GetComponent<TMP_Text>();
        _label.enabled = false;
        DisplayCoordinates();
        ColorCoordinates();
    }

    private void Update()
    {
        ColorCoordinates();
        ToggleLabels();
        if (Application.isPlaying)
        {
            return;
        }
        UpdateObjectName();
        DisplayCoordinates();
    }

    private void ColorCoordinates()
    {
        if (_gridManager == null) return;

        Node node = _gridManager.GetNode(_coordinates);
        if (node == null) return;

        if (!node.isWalkable)
            _label.color = blockedColor;
        else if(node.isPath)
            _label.color = pathColor;
        else if(node.isExplored)
            _label.color = exploredColor;
        else
            _label.color = defaultColor;
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _label.enabled = !_label.enabled;
        }
    }

    private void UpdateObjectName()
    {
        transform.parent.name = _coordinates.ToString();
    }

    private void DisplayCoordinates()
    {
        var position = transform.parent.position;
        _coordinates.x = Mathf.RoundToInt(position.x / EditorSnapSettings.move.x);
        _coordinates.y = Mathf.RoundToInt(position.z / EditorSnapSettings.move.z);

        _label.text = $"{_coordinates.x};{_coordinates.y}";
    }
}
