using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private RigidBody rb;
    public float speed;
    private int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<RigidBody>();
        score = 0;
        SetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * speed;
        float v = Input.GetAxis("Vertical") * speed;

        Vector3 vel = rb.velocity;
        vel.x = h;
        vel.z = v;
        rb.velocity = vel;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Triangle")) 
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.toString();
    }
}
