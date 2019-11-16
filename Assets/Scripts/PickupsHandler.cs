using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsHandler : MonoBehaviour
{
    
    Scores score;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            score.Player += 1;
            Debug.Log(score.Player);
            Destroy(gameObject);
        }
    }
}
