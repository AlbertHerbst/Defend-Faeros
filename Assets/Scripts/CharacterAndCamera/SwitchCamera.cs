using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwitchCamera : MonoBehaviour {

    public Camera FPScam, TopDownCam;
    public characterController charControl;
    public CameraController camControl;
    public camMouseLook camMouseLook;
    bool lockMouse;
    public RectTransform waves;


	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        lockMouse = true;
        FPScam.enabled = false;
        camMouseLook.enabled = false;       
        charControl.enabled = false;
        TopDownCam.enabled = true;
        camControl.enabled = true;
        
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            Debug.Log("Camera Switched");
            FPScam.enabled = !FPScam.enabled;
            camMouseLook.enabled = !camMouseLook.enabled;
            charControl.enabled = !charControl.enabled;

            if (lockMouse)
            {
                camMouseLook.enabled = true;
                Debug.Log("Mouse Locked");
                Cursor.lockState = CursorLockMode.Locked;
                lockMouse = false;
                //waves.Rotate(new Vector3(0f, 90f, 0f));
                waves.rotation = new Quaternion(0f, 90f, 0f, 0f);
            }
            else
            {
                Debug.Log("Mouse Unlocked");
                Cursor.lockState = CursorLockMode.None;
                lockMouse = true;
                //waves.Rotate(new Vector3(0f, -90f, 0f), Space.World );
                waves.rotation =  new Quaternion(20f, 0f, 0f, 0f);
            }

            //Cursor.visible = !Cursor.visible;

            TopDownCam.enabled = !TopDownCam.enabled;
            camControl.enabled = !camControl.enabled;      
                       
        }

        
    }
}
