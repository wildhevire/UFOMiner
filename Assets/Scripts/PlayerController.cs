
#define TAPONPLAYER //undefine or remove this for drag anywhere to control player


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector2 origin,target,pivot;
    float distance;
    public float maxForce = 100;
    Rigidbody2D rigid;
    
    TrailRenderer trail;
  
    [SerializeField]GameObject objText;
    Text scoreText;

    [Header("Slow Motion When Aiming")]
    public bool SlowMotion = true;
    public float slowFactor = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        trail.startColor = new Color(0, 255, 247, 1);
        trail.endColor = new Color(0, 255, 247, 0);
        scoreText = objText.GetComponent<Text>();
    }


    // Update is called once per frame


#if TAPONPLAYER
    /* for mousedrag, its need to drag from the player */

    private void OnMouseDrag()
    {
        if (SlowMotion)
            {

                Time.timeScale = slowFactor;
                Time.fixedDeltaTime = Time.timeScale * 0.1f;

            }
        origin = this.transform.position;
        pivot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target = pivot - new Vector2(origin.x,origin.y); 
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = rotation;

        distance = Vector2.Distance(origin, pivot);
        distance = Mathf.Clamp(distance, 0, maxForce);
        Debug.DrawRay(origin, -target.normalized * distance);

    }
    private void OnMouseUp()
    {
        if (SlowMotion)
        {
            Time.timeScale = 1;

        }        
        rigid.velocity =-target.normalized * distance;

    }






#else

    /* This can drag from anywhere */
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (SlowMotion)
            {

                Time.timeScale = slowFactor;
                Time.fixedDeltaTime = Time.timeScale * 0.1f;

            }
            origin = this.transform.position;
            pivot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target = pivot - new Vector2(origin.x, origin.y);
            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            this.transform.rotation = rotation;

            distance = Vector2.Distance(origin, pivot);
            distance = Mathf.Clamp(distance, 0, maxForce);
            Debug.DrawRay(origin, -target.normalized * distance);
        }
        else
        if (Input.GetMouseButtonUp(0))
        {
            if (SlowMotion)
            {
                Time.timeScale = 1;

            }
            rigid.velocity = -target.normalized * distance;
        }
    }


#endif

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PickUp")
        {
            ScoresData.Player += 1;
            PickupsSpawner.pickUpCount -= 1;
            Debug.Log("Player : "+ScoresData.Player);
            collision.gameObject.tag = "Untagged";
            Destroy(collision.gameObject);
            scoreText.text ="Player : " + ScoresData.Player;
        }
    }
}
