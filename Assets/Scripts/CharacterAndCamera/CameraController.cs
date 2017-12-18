using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax, minCamSize, maxCamSize;

}


public class CameraController : MonoBehaviour {

    public float speed, ZoomScroll, ZoomKeypad;
    public float cameraHeight;
    
    public Camera cam;

    public Boundary boundary = new Boundary();

    void OnDisable()
    {
        Debug.Log("Disabled");
        Vector3 stop = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().velocity = stop;
    }


    void Update()
    {
        

        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKey(KeyCode.KeypadPlus)) //ZOOM IN
        {
            transform.Translate(0, -1, 0,Space.World);
          //  Debug.Log("Zoom In");
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKey(KeyCode.KeypadMinus)) //ZOOM OUT
        {
            transform.Translate(0, 1, 0, Space.World);
            //Debug.Log("Zoom Out");
        }

        //Camera Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // float moveY = Input.GetAxis("Mouse ScrollWheel") * ZoomScroll; //Used for rigidbody y axis zooming
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;
        //Camera Boundary stuff

        transform.position = new Vector3(
           Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
           Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.minCamSize, boundary.maxCamSize),
           Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
           );


        //Camera zooming shizzle
        /* if (Input.GetKey(KeyCode.KeypadPlus))
             if (cam.orthographicSize > boundary.minCamSize)
             {
                 cam.orthographicSize -= ZoomKeypad;
                 Debug.Log("zoominkeypad");
             }

         if (Input.GetKey(KeyCode.KeypadMinus))
             if (cam.orthographicSize < boundary.maxCamSize)
             {
                 cam.orthographicSize += ZoomKeypad;
                 Debug.Log("zoomoutkeypad");
             }


         if (Input.GetAxis("Mouse ScrollWheel") > 0)
         {
             if (cam.orthographicSize > boundary.minCamSize)
             {
                 cam.orthographicSize -= ZoomScroll;
                 Debug.Log("zoominscroll");
             } 
         }

         if (Input.GetAxis("Mouse ScrollWheel") < 0)
         {
             if (cam.orthographicSize < boundary.maxCamSize)
             {
                 cam.orthographicSize += ZoomScroll;
                 Debug.Log("zoomoutscroll");
             }

         }*/


    }
}
