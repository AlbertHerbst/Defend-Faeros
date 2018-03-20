using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEnemySpawner : MonoBehaviour {

    public GameObject Enemy;
    public float spawnCountDown;
    

	// Use this for initialization
	void Start () {
        spawnCountDown = Random.Range(0.5f, 2);
        
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnCountDown <= 0f)
        {
            Instantiate(Enemy, gameObject.transform.position, gameObject.transform.rotation);
           
            spawnCountDown = 4f;
            
        }
        else
        {
            spawnCountDown -= Time.deltaTime;
        }
	}
}
