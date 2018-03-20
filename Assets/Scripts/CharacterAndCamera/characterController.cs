using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

    public float speed = 10f;
    public float jumpHeight = 10f;
    public Rigidbody rb;
    public bool inAir = false;
    public Collider col;
    Animator anim;
    
    Vector3 forwardF, leftF, rightF, backwardF;
    public GameObject rifle;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

      

        //x = 0.2762 Y= -0.0462 Z =0.03

        



    }

    Vector3 negative = new Vector3(0.1f, 0, 0.1f);

    void Update()
	{
        anim.SetFloat("speed", Input.GetAxis("Vertical"));

        
        if (Input.GetKeyDown(KeyCode.Space) && inAir == false)
        {
            inAir = true;
          
            rb.velocity = new Vector3(0, jumpHeight, 0);
        }
        if (rb.velocity.y < 0f)
      {
            Vector3 velocity = rb.velocity;
            velocity.x = 0;
            velocity.z = 0;
            velocity.y *= 0.4f;
            rb.AddForce(velocity);
      }
        if (Input.anyKey)
        {
            rb.drag = 1f;
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddRelativeForce(Vector3.forward * speed * 100 * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.AddRelativeForce(Vector3.back * speed * 100 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {

                rb.AddRelativeForce(Vector3.left * speed * 100 * Time.deltaTime);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.AddRelativeForce(Vector3.right * speed * 100 * Time.deltaTime);
            }
        }
        else
        {
            rb.drag = 1.5f;
        }
        

      

        


    }

    private void OnCollisionStay(Collision collision)
    {
        inAir = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        inAir = true;
    }


    /* private void OnCollisionExit(Collision collision)
     {
         inAir = true;
     }*/

}
