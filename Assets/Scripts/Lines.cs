using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class Lines : MonoBehaviour
{
    public GameObject mainPt;
    LineRenderer lineRenderer;
    string[] coords;
    private Vector3[] vP;
    int numPts = 20;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.01f;    // set line width

        rend = GetComponent<Renderer>();
        rend.material.color = Color.red;    // set line color

        string path = "Assets/Resources/Points.txt";
        // Read the text directly from the Points.txt file
        StreamReader reader = new StreamReader(path); 
        string content = reader.ReadToEnd();
        reader.Close();
        coords = content.Split(new string[] {"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);

        DrawLine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawLine() {
        numPts = coords.Length + 1;
        Debug.Log("Number of points: " + numPts);
        vP = new Vector3[numPts];
        vP[0] = mainPt.transform.position;
        for (int i = 1; i < numPts; i++)
        {
            string coord = coords[i-1];
            //string[] vals = coord.Split(',');
            string[] vals = coord.Split(null);
            float x = float.Parse(vals[0])/150;
            float y = float.Parse(vals[1])/150;
            float z = float.Parse(vals[2])/150 - 2;
            /*
            if (i == 1 || i == 201) {
                Debug.Log(x + " " + y + " " + z);
            }
            */
            Vector3 pt = new Vector3(x,y,z);
            vP[i] = pt;
        }

        for (int i = 0; i < numPts; i++)
        {
            lineRenderer.positionCount = numPts;
            lineRenderer.SetPositions(vP);
        }
 
     }
}
