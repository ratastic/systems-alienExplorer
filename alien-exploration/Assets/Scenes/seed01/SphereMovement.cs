using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphereMovement : ObjectMovement
{
    public float speed = 5f;
    private Rigidbody rb;
    public Transform camTF;
    //public bool ballRolling;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // canRoll = true;
    }

    void Update()
    {
        if (canRoll == true)
        {
            BallRoll();
        }
    }

    // Update is called once per frame
    public void BallRoll()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(camTF.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(-camTF.right * speed);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(camTF.forward * speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(-camTF.forward * speed);
        }
    }
}
