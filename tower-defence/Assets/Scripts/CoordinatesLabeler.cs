using UnityEngine;
using UnityEditor;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinatesLabeler : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.black;

    private TMP_Text _label;
    private Vector2Int _coordinates;
    private WayPoint _waypoint;

    private void Awake()
    {
        _label = GetComponent<TMP_Text>();
        _waypoint = GetComponentInParent<WayPoint>();
        DisplayCoordinates();
        ColorCoordinates();
    }

    private void Update()
    {
        ToggleLabels();
        if (Application.isPlaying)
        {
            return;
        }
        UpdateObjectName();
        ColorCoordinates();
    }

    private void ColorCoordinates()
    {
        _label.color = _waypoint.IsPlaycable ? defaultColor : blockedColor;
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
