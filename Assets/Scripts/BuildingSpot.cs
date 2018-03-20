using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpot : MonoBehaviour {

    BuildingManager bm;

    private void Start()
    {
        bm = GameObject.FindObjectOfType<BuildingManager>();
    }
    public bool hasTower = false;

    //TODO: Make it so this can place resource generators *ON DESIGNATED SPOTS*
    void OnMouseUp()
    {

        Debug.Log("BuildingSpot Clicked.");

       

        if (bm.tower >= 0 && !hasTower)
        {

            ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
            if (sm.money < bm.towers[bm.tower].GetComponent<Tower>().cost)
            {
                Debug.Log("You're too poor.");
                return;
            }

            sm.money -= bm.towers[bm.tower].GetComponent<Tower>().cost;
            //FIXME: Right now we assume that we are an object nested in a parent.
            GameObject tower = Instantiate(bm.towers[bm.tower], new Vector3(transform.position.x, transform.position.y - 4, transform.position.z), transform.rotation);
            tower.transform.parent = this.transform;
            Destroy(GameObject.FindGameObjectWithTag("delete"));
            deletePreviews();
            hasTower = true;
        }   


    }

    void OnMouseEnter()
    {
        if (bm.tower >= 0)
        {
            Instantiate(bm.previews[bm.tower], new Vector3(transform.position.x, transform.position.y + 0.16f, transform.position.z), transform.rotation);
        }
       
    }

    void OnMouseExit()
    {
        deletePreviews();
    }

    void deletePreviews()
    {
        GameObject[] delete = GameObject.FindGameObjectsWithTag("delete");
        foreach (GameObject item in delete)
        {
            Destroy(item);
        }
    }

}
