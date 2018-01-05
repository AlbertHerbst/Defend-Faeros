using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    //The BuildingManager manages upgrades and such for the towers

    public int tower = -1;
    public GameObject selectedTower;
    public GameObject[] towers;
    public GameObject[] previews;
	


    public void SelectTowerType(GameObject prefab)
    {
        Debug.Log("Button Pressed");
        selectedTower = prefab;
    }

    public void selectTower(int tower)
    {
        this.tower = tower;
    }
}
