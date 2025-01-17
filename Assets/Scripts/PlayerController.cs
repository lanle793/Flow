﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * speed;
        float v = Input.GetAxis("Vertical") * speed;

        var rotationVector = transform.rotation.eulerAngles;

        if (h > 0) {
            Debug.Log("Right");
            rotationVector.z = 0;
            transform.rotation = Quaternion.Euler(rotationVector);
        } else if (h < 0) {
            Debug.Log("Left");
            rotationVector.z = 10;
            transform.rotation = Quaternion.Euler(rotationVector);
        }

        if (v > 0) {
            Debug.Log("Forward");
        } else if (v < 0) {
            Debug.Log("Backward");
        }

        Vector3 vel = rb.velocity;
        vel.x = h;
        vel.z = v;
        rb.velocity = vel;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Triangle")) 
        {
            Debug.Log("Add 1 point");
            //other.gameObject.SetActive(false);
            score = score + 1;
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}



// Adapted from: https://www.youtube.com/watch?v=az7w9nwQRDU