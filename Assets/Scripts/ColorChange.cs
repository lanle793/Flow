using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //rend.material.color = Color.blue;
    }

    void OnTriggerEnter(Collider other)
    {
        rend.material.color = Color.gray;
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collide");
        rend.material.color = Color.yellow;
    }

    void OnCollisionExit(Collision col)
    {
        rend.material.color = Color.white;
    }
}
