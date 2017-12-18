using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

    public Camera FPScam, TopDownCam;
    public characterController charControl;
    public CameraController camControl;
    public camMouseLook camMouseLook;
    bool mouseVisible = true;
    //public FirstPersonController FPSS;


	// Use this for initialization
	void Start () {
        
        FPScam.enabled = false;
        //camMouseLook.enabled = false;       
        charControl.enabled = false;
        TopDownCam.enabled = true;
        camControl.enabled = true;
        //Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Camera Switched");
            FPScam.enabled = !FPScam.enabled;
            camMouseLook.enabled = !camMouseLook.enabled;
            charControl.enabled = !charControl.enabled;

            Cursor.visible = !Cursor.visible;

            TopDownCam.enabled = !TopDownCam.enabled;
            camControl.enabled = !camControl.enabled;      
                       
        }

        
    }
}
