using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelRotation : MonoBehaviour {

    public float rotateX, rotateY, rotateZ;
    public bool rotating = false;
	
	
	// Update is called once per frame
	void Update () {
        if (rotating)
        {
            transform.Rotate(new Vector3(rotateX * Time.deltaTime, rotateY * Time.deltaTime, rotateZ * Time.deltaTime));
        }
        
	}
}
