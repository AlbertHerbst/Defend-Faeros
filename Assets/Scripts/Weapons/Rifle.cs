using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour {
   
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    
  

    public int cost = 5;

    public float fireCooldown = 0.5f;
    public float fireCooldownLeft = 1f;

    public float damage = 1;
    public float radius = 0;
	
	// Update is called once per frame
	void Update () {
        fireCooldownLeft -= Time.deltaTime;
        


        if (Input.GetMouseButton(0))
        {
          
            if (fireCooldownLeft <= 0)
            {                 
                    Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                    fireCooldownLeft = fireCooldown;
            }
        }
       
        
        
       
	}

    

}


