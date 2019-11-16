using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 origin, target;
    float distance;
    public float maxForce = 5;
    public float Force = 5;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            origin = this.transform.position;
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            this.transform.rotation = rotation;

            distance = Vector2.Distance(origin, target);
            distance = Mathf.Clamp(distance, 0, maxForce);
            Debug.DrawRay(origin, -target.normalized * distance);
        }else
        if (Input.GetMouseButtonUp(0)) {
            rigid.velocity = -target.normalized * distance;
        }
    }

    //private void OnMouseDrag()
    //{
    //    origin = this.transform.position;
    //    target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
    //    float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
    //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //    this.transform.rotation = rotation;
        
    //    distance = Vector2.Distance(origin, target);
    //    distance = Mathf.Clamp(distance, 0, maxForce);
    //    Debug.DrawRay(origin, -target.normalized * distance);
    //}
    //private void OnMouseUp()
    //{
    //    //rigid.AddForce(-target.normalized * distance * Force);
    //    rigid.velocity = -target.normalized * distance;
    //}
}
