using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    Mesh mesh;
    void Start()
    {

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),  // Bottom left
            new Vector3(3, 0, 0),  // Bottom right
            new Vector3(3, 1, 0),  // Right middle
            new Vector3(5, 0, 0),  // Arrow tip
            new Vector3(3, -1, 0), // Right bottom
            new Vector3(3, -2, 0), // Bottom right tail
            new Vector3(0, -2, 0), // Bottom left tail
        };

        // Define triangles for the arrow shape
        mesh.triangles = new int[]
        {
            0, 1, 2, // Bottom right triangle
            0, 2, 3, // Right middle triangle
            0, 3, 4, // Right bottom triangle
            0, 4, 5, // Bottom right tail triangle
            0, 5, 6  // Bottom left tail triangle
        };

        // Recalculate normals for proper lighting
        //mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
