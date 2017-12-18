using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

    public float speed = 10f;
    public float jumpHeight = 10f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        float jump = Input.GetAxis("Jump") * jumpHeight;

        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        jump *= Time.deltaTime;

        transform.Translate(straffe, jump, translation);

       

        /*if (Input.GetKeyDown("Jump"))
        {
            transform.Translate(0, jumpHeight, 0);
        }*/
	}
}
