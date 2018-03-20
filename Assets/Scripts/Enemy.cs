using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject pathGO;
    Animator anim;

    Transform targetPathNode;
    int pathNodeIndex = 0;
    public float health = 1f;
    public float speed = 5f;
    float waitUntilDestroy = 4.6f;
    bool die = false;

    public int moneyValue = 1;

	// Use this for initialization
	void Start () {
        pathGO = GameObject.Find("Path");
        anim = GameObject.FindObjectOfType<Animator>();

        if ((GameObject.FindObjectOfType<WaveManager>()))
        {
            health = health * Mathf.Pow(GameObject.FindObjectOfType<WaveManager>().difficultyMultiplier, GameObject.FindObjectOfType<WaveManager>().wave - 1);
        }
           
        
        
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
        if (die)
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            if (waitUntilDestroy <= 1)
            {
                gameObject.GetComponent<Collider>().enabled = false;
            }
            if (waitUntilDestroy <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                waitUntilDestroy -= Time.deltaTime;
            }
        }
       
        if (targetPathNode == null)
        {
            GetNextPathNode();
            if(targetPathNode == null)
            {
                //Shit fam there ain't no more path
            }
        }
        Vector3 targetposition = new Vector3(targetPathNode.position.x, gameObject.transform.position.y, targetPathNode.position.z);

        Vector3 dir = targetposition - this.transform.localPosition;

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
            if (!die)
            {
                transform.Translate(dir.normalized * distThisFrame, Space.World);
                Quaternion targetRotation = Quaternion.LookRotation(dir);
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 5);
            }
            
        }
	}

    void ReachedGoal()
    {
        if (GameObject.FindObjectOfType<ScoreManager>())
        {
            GameObject.FindObjectOfType<ScoreManager>().LooseLife();
        }
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
        if (GameObject.FindObjectOfType<ScoreManager>())
        {
            GameObject.FindObjectOfType<ScoreManager>().money += moneyValue;
        }
        anim.SetBool("Die", true);
        die = true;
        

        
    }
}


