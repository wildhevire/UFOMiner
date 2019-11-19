using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHelper : MonoBehaviour
{
    

    Transform target;

    Rigidbody2D rigid;
    TrailRenderer trail;
    
    public int number;
    [SerializeField] GameObject scorePrefab;
    [SerializeField] GameObject namePrefab;
    Text text;
    Text nameText;

    EnemySpawner es;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        trail.startColor = Color.red;
        trail.endColor = new Color(1, 0, 0, 0);
        es = transform.parent.GetComponent<EnemySpawner>();
    }
    void Start()
    {
        number = transform.GetSiblingIndex();
        target = FindTarget();
        text = Instantiate(scorePrefab, new Vector3(150, 30 * number + 50) ,Quaternion.identity, FindObjectOfType<Canvas>().transform).transform.GetComponent<Text>();
        nameText = Instantiate(namePrefab, gameObject.transform.position, Quaternion.identity, FindObjectOfType<Canvas>().transform).transform.GetComponent<Text>();
        nameText.fontSize = 16;
        nameText.alignment = TextAnchor.MiddleCenter;
        nameText.text = "Enemy" + (number + 1) ;

        text.text = "Enemy"+ (number+1) + " : "+ ScoresData.Enemy[number] + "  ";

    }

    void Update()
    {
        if (target != null)
        {
            float maxForce = Random.Range(es.minForce, es.maxForce);
            Vector3 direction = (target.position - transform.position).normalized;

            if(es.difficulty == EnemySpawner.Difficulties.Easy)
            {
                // Addforce turn enemy slow at moving around, which means easy mode
                rigid.AddForce(direction * maxForce);
            }
            else if (es.difficulty == EnemySpawner.Difficulties.Hard)
            {
                // Velocity for hard mode, enemy can pick pickups easily 
                rigid.velocity = direction * maxForce; 
            }



        }
        nameText.transform.position = new Vector3(Camera.main.WorldToScreenPoint(transform.position).x, Camera.main.WorldToScreenPoint(transform.position).y + 30) ;
        text.text = "Enemy" + (number + 1) + " : " + ScoresData.Enemy[number];

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
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("PickUp");
        float minDistance = Mathf.Infinity;
        Transform closest;

       if (pickups.Length == 0)
           return null;

        closest = pickups[0].transform;
        for (int i = 1; i < pickups.Length; ++i)
        {
            float distance = (pickups[i].transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                closest = pickups[i].transform;
                minDistance = distance;
            }
        }
        return closest;
    }
}

