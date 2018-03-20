using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testforce : MonoBehaviour {

    public float topSpeed = 10f;
    public float drag = 0f;
    public float acceleration = 10f;
    public float currentSpeed;
    public Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
/*


        if (Input.GetAxis("Horizontal") > 0)
        {
            drag = (acceleration / topSpeed);
            rb.velocity += (Vector3.right * acceleration - (drag * rb.velocity)) * Time.fixedDeltaTime;
            currentSpeed = rb.velocity.magnitude;
        }*/
        
    }
}
