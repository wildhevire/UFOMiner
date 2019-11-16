using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 origin,target,pivot;
    float distance;
    public float maxForce = 10;

    Rigidbody2D rigid;

    
    // Start is called before the first frame update
    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame


    /* This can drag from anywhere */
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
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
            rigid.velocity = -target.normalized * distance;
        }
    }

    /* for mousedrag, its need to drag from the player */

    //private void OnMouseDrag()
    //{

    //    origin = this.transform.position;
    //    pivot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    target = pivot - new Vector2(origin.x,origin.y); 
    //    float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
    //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //    this.transform.rotation = rotation;

    //    distance = Vector2.Distance(origin, pivot);
    //    distance = Mathf.Clamp(distance, 0, maxForce);
    //    Debug.DrawRay(origin, -target.normalized * distance);
        
    //}
    //private void OnMouseUp()
    //{
       
    //    rigid.velocity =-target.normalized * distance;
       
    //}
}
