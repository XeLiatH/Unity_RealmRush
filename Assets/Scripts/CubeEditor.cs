using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        Vector2Int gridPosition = waypoint.GetGridPosition();
        transform.position = new Vector3(gridPosition.x, 0f, gridPosition.y);
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        string labelText = transform.position.x / gridSize + "," + transform.position.z / gridSize; ;
        TextMesh coordinateLabel = GetComponentInChildren<TextMesh>();

        coordinateLabel.text = labelText;
        gameObject.name = labelText;
    }
}
