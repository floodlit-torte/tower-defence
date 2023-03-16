using UnityEngine;
using UnityEditor;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinatesLabeler : MonoBehaviour
{
    private TMP_Text _label;
    private Vector2Int _coordinates;

    private void Awake()
    {
        _label = GetComponent<TMP_Text>();
        DisplayCoordinates();
    }

    private void Update()
    {
        if (Application.isPlaying)
        {
            return;
        }
        UpdateObjectName();
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
