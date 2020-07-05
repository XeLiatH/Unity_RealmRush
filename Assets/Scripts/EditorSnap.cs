using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [Range(1f, 20f)] [SerializeField] float gridSize = 10f;

    void Update()
    {
        float x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        float z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(x, 0f, z);
    }
}
