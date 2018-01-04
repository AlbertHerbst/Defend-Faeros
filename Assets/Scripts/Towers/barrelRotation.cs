using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelRotation : MonoBehaviour {

    public float rotateX, rotateY, rotateZ;
	
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(rotateX * Time.deltaTime, rotateY * Time.deltaTime, rotateZ * Time.deltaTime));
	}
}
