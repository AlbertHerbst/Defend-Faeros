using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingGun : MonoBehaviour {
   
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
  

    public int cost = 5;

    public float fireCooldown = 0.5f;
    float fireCooldownLeft = 0f;

    public float damage = 1;
    public float radius = 0;

	// Use this for initialization
	void Start () {
        
        

	}
	
	// Update is called once per frame
	void Update () {
        fireCooldownLeft -= Time.deltaTime;
        if (Input.GetMouseButton(0) && fireCooldownLeft <= 0)
        {
            Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            fireCooldownLeft = fireCooldown;
        }
	}

    void ShootAt(Enemy e) {     
       
       
    }

}


