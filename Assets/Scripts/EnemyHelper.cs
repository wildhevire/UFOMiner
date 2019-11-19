using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHelper : MonoBehaviour
{
    public float speed = 10;

    Transform target;

    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        target = FindTarget();
        
    }

     void Update()
    {
        if (target != null)
        {
            float maxForce = Random.Range(5, 10);
            Vector3 direction = (target.position - transform.position).normalized;


            // Velocity for hard mode, enemy can pick pickups easily 
            // rb.velocity = direction * maxForce; 

            // Addforce turn enemy slow at moving around, which means easy mode
            rb.AddForce(direction * maxForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PickUp")
        {
            Scores.Enemy += 1;
            PickupsSpawner.pickUpCount -= 1;
            Debug.Log("Enemy : "+Scores.Enemy);
            collision.gameObject.tag = "Untagged";
            Destroy(collision.gameObject);
            target = FindTarget();
        }
    }

    public Transform FindTarget()
    {
        GameObject[] candidates = GameObject.FindGameObjectsWithTag("PickUp");
        float minDistance = Mathf.Infinity;
        Transform closest;

       if (candidates.Length == 0)
           return null;

        closest = candidates[0].transform;
        for (int i = 1; i < candidates.Length; ++i)
        {
            float distance = (candidates[i].transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                closest = candidates[i].transform;
                minDistance = distance;
            }
        }
        return closest;
    }
}

