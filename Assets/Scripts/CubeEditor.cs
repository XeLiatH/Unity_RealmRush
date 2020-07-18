using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [Range(1f, 20f)] [SerializeField] float gridSize = 10f;

    TextMesh coordinateLabel;

    void Update()
    {
        float x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        float z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(x, 0f, z);

        coordinateLabel = GetComponentInChildren<TextMesh>();

        string labelText = transform.position.x / gridSize + "," + transform.position.z / gridSize; ;

        coordinateLabel.text = labelText;
        gameObject.name = labelText;
    }
}
