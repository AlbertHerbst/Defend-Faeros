using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpToPosition : MonoBehaviour {

    public float yPos;
    bool stepone = true;
    bool steptwo = false;
    Vector3 finalpos, finalpos2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (yPos != 0)
        {
            Vector3 finalPos = new Vector3(transform.position.x, yPos, transform.position.z);
          
            if (transform.position != finalPos)
            {
                transform.position = Vector3.Lerp(transform.position, finalPos, 0.1f);
            }
            
            

            
            


        }
		
	}
}
//transform.position.y + 0.16f