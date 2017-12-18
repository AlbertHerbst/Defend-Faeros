using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    //The BuildingManager manages upgrades and such for the towers

    public GameObject selectedTower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SelectTowerType(GameObject prefab)
    {
        selectedTower = prefab;
    }
}
