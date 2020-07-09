using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Triangle : MonoBehaviour
{
    Mesh mesh;
    MeshRenderer rend;

    Vector3[] vertices;
    int[] triangles;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        MakeMeshData();
        CreateMesh();
        rend.material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeMeshData()
    {
        // create an array of vertices
        vertices = new Vector3[]{new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0)};
        
        // create an array of integers
        triangles = new int[]{0, 1, 2};
    }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collide");
        rend.material.color = Color.yellow;
    }

    void OnCollisionExit(Collision col)
    {
        rend.material.color = Color.blue;
    }
}