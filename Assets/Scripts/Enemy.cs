using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject pathGO;

    Transform targetPathNode;
    int pathNodeIndex = 0;
    public float health = 1f;
    public float speed = 5f;


    public int moneyValue = 1;

	// Use this for initialization
	void Start () {
        pathGO = GameObject.Find("Path");
       
        
            health = health * Mathf.Pow(GameObject.FindObjectOfType<WaveManager>().difficultyMultiplier, GameObject.FindObjectOfType<WaveManager>().wave);
        
        
	}

    void GetNextPathNode()
    {
        if (pathNodeIndex < pathGO.transform.childCount)
        {
            targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
        }
        else
        {
            targetPathNode = null;
            ReachedGoal();
        }
        
    }

	// Update is called once per frame
	void Update () {
		if (targetPathNode == null)
        {
            GetNextPathNode();
            if(targetPathNode == null)
            {
                //Shit fam there ain't no more path
            }
        }


        Vector3 dir = targetPathNode.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude < distThisFrame)
        {
            //At the node fam
            targetPathNode = null;
        }
        else
        {    
            //TODO: COnsider ways to smooth this motion

            //Move towards the node
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 5);
        }
	}

    void ReachedGoal()
    {
        GameObject.FindObjectOfType<ScoreManager>().LooseLife();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //TODO: DO This more safely(?)
        GameObject.FindObjectOfType<ScoreManager>().money += moneyValue;
        Destroy(gameObject);
    }
}


