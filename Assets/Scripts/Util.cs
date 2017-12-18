using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {


   
    public Canvas GUI;
   

	// Use this for initialization
	void Start () {
       
        //GUI = GameObject.FindObjectOfType<Canvas>();
        GUI.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("p")) //Release Mouse
        {
            
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Pressed Escape");
           

        }
        
    }
}
