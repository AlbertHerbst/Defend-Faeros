using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    //The BuildingManager manages upgrades and such for the towers

    public GameObject selectedTower;

	


    public void SelectTowerType(GameObject prefab)
    {
        Debug.Log("Button Pressed");
        selectedTower = prefab;
    }
}
