using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject weaponsandtowers;
    public Button normal, explosion;
    bool active;
    public camMouseLook mouselook;

    private void Start()
    {
        active = false;
        weaponsandtowers.SetActive(false);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (weaponsandtowers.activeSelf)
            {
                weaponsandtowers.SetActive(false);
                active = false;
                mouselook.enabled = true;

                if (GameObject.FindObjectOfType<characterController>().enabled)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }

                
                
            }
            else
            {
                weaponsandtowers.SetActive(true);
                active = true;
                mouselook.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                
            }
           
        }
	}
}
