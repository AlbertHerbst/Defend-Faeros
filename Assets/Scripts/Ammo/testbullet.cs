using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testbullet : MonoBehaviour {

    public float speed = 15f;
    public float damage = 1f;
    Rigidbody rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = -transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.GetComponent<Enemy>())
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }        
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        Enemy fiende = collision.gameObject.GetComponent<Enemy>();
        doDamage(fiende);
        Destroy(this.gameObject);
    }


    void doDamage(Enemy f) {
        f.TakeDamage(damage);
        Destroy(this.gameObject);
    }




}
