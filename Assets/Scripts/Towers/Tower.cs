using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {


    Transform rotY, rotX; //Parts of the turret that rotate in the X and Y planes
    public float rotationSpeed;
    public float range = 10f;
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public barrelRotation br;
    lerpToPosition lerptopos;

    public int cost = 5;

    public float fireCooldown = 0.5f;
    float fireCooldownLeft = 0f;

    public float damage = 1;
    public float radius = 0;

	// Use this for initialization
	void Start () {
        rotY = transform.Find("RotateY");
        rotX = transform.Find("RotateX");
        lerptopos = GetComponent<lerpToPosition>();
        lerptopos.yPos = transform.position.y + 4.16f;

	}
	
	// Update is called once per frame
	void Update () {
        //TODO: Optimize this!
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        Enemy nearestEnemy = null;
        float dist = Mathf.Infinity;

        foreach (Enemy e in enemies)
        {
            float d = Vector3.Distance(this.transform.position, e.transform.position);
            if (nearestEnemy == null || d < dist)
            {
                nearestEnemy = e;
                dist = d;
            }
        }

        if (nearestEnemy == null)
        {
           // Debug.Log("No Enemies?");
            return;
        }

        
        Vector3 dir = nearestEnemy.transform.position - this.transform.position;
        Quaternion lookRot = Quaternion.LookRotation( dir );
        if (dir.magnitude <= range)
        {
            if (br != null)
            {
                br.rotating = true;
            }
          

            Quaternion fromY = rotY.rotation;
            Quaternion fromX = rotX.rotation;

            Quaternion toY = Quaternion.Euler(0f, lookRot.eulerAngles.y, 0f);
            Quaternion toX = Quaternion.Euler(lookRot.eulerAngles.x, lookRot.eulerAngles.y, -90f);

            rotY.rotation = Quaternion.Lerp(rotY.rotation, toY, rotationSpeed * Time.deltaTime);
            rotX.rotation = Quaternion.Lerp(rotX.rotation, toX, rotationSpeed * Time.deltaTime);
        }
        else
        {
            if (br != null)
            {
                br.rotating = false;
            }
            
        }

        fireCooldownLeft -= Time.deltaTime;
        if (fireCooldownLeft <= 0 && dir.magnitude <= range)
        {
            fireCooldownLeft = fireCooldown;
            ShootAt(nearestEnemy);
        }
	}

    void ShootAt(Enemy e) {
       
       
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);

        GatlingBullet_Tower b = bulletGO.GetComponent<GatlingBullet_Tower>();
        b.target = e.transform;
        b.damage = damage;
        b.radius = radius;
    }

}


