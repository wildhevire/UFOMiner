using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHelper : MonoBehaviour
{
    public float speed = 10;

    Transform target;

    Rigidbody2D rb;
    TrailRenderer trail;
    
    public int number;
    [SerializeField]GameObject prefab;
    Text text;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        trail.startColor = Color.red;
        trail.endColor = new Color(1, 0, 0, 0);
    }
    void Start()
    {
        number = transform.GetSiblingIndex();
        //name = this.gameObject.name;
        target = FindTarget();
        //Debug.Log();
        text = Instantiate(prefab,new Vector3(150 * (number + 2) + 50,20) ,Quaternion.identity, FindObjectOfType<Canvas>().transform).transform.GetComponent<Text>();
        text.text = "Enemy"+ (number+1) + " : "+ ScoresData.Enemy[number] + "  ";
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
            text.text = "Enemy" + number + " : " + ScoresData.Enemy[number];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PickUp")
        {
            ScoresData.Enemy[number] += 1;
            PickupsSpawner.pickUpCount -= 1;
            Debug.Log("Enemy"+number + " : "+ ScoresData.Enemy[number]);
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

