using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsSpawner : MonoBehaviour
{
   
    //public List<Vector2> pickupPos;
    Vector2[] pickupPos;
    public int banyakPickup = 20;
    [SerializeField] GameObject pickup;
    // Start is called before the first frame update
    void Start()
    {
        pickupPos = new Vector2[banyakPickup];
        for (int i = 0; i < banyakPickup; i++)
        {
            pickupPos[i] = randomPos();
            Instantiate(pickup, new Vector3(pickupPos[i].x, pickupPos[i].y, 0), Quaternion.identity);
        }

        //foreach (Vector2 pos in pickupPos) {
        //    Vector2 tmp = randomPos();
        //    pickupPos.Add(tmp);
        //    Instantiate(pickup, new Vector3(pickupPos[i].x, pickupPos[i].y, 0), Quaternion.identity);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector2 randomPos()
    {

        var x = Random.Range(-38, 38);
        var y = Random.Range(-12, 12);

        return new Vector2(x, y);
    }
}
