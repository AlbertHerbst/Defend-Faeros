using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpot : MonoBehaviour {
    //TODO: Make it so this can place resource generators *ON DESIGNATED SPOTS*
    void OnMouseUp()
    {

        Debug.Log("BuildingSpot Clicked.");

        BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
        if (bm.selectedTower != null)
        {

            ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
            if (sm.money < bm.selectedTower.GetComponent<Tower>().cost)
            {
                Debug.Log("You're too poor.");
                return;
            }

            sm.money -= bm.selectedTower.GetComponent<Tower>().cost;
            //FIXME: Right now we assume that we are an object nested in a parent.
            Instantiate(bm.selectedTower, new Vector3(transform.parent.position.x, transform.parent.position.y +4, transform.parent.position.z), transform.parent.rotation);
            Destroy(transform.parent.gameObject);
        }
    }
}
