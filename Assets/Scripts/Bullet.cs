using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 15f;
    public Transform target;
    public float damage = 1f;
    public float radius = 0f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (target == null)
        {
            //Our enemy went away!
            Destroy(gameObject);
            return;
        }


        Vector3 dir = target.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude < distThisFrame)
        {
            //At the node fam
            DoBulletHit();
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

    void DoBulletHit()
    {
        //TODO: Exploading bullet with area of effect? Solve it fam
        if (radius == 0)
        {
            target.GetComponent<Enemy>().TakeDamage(damage);
        }
        else
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider c in cols)
            {
                Enemy e = c.GetComponent<Enemy>();
                if (e != null)
                {
                    target.GetComponent<Enemy>().TakeDamage(damage);
                }
            }
        }
        Destroy(gameObject);
    }
}
