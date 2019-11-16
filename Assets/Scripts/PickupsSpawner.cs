using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsSpawner : MonoBehaviour
{
   
    //public static List<GameObject> pickupPos;
    //Vector2[] pickupPos;
    public static int pickUpCount = 20;
    [SerializeField] GameObject pickup;
 
    // Start is called before the first frame update
    void Start()
    {
        //pickupPos = new Vector2[banyakPickup];
        //for (int i = 0; i < banyakPickup; i++)
        //{
        //    pickupPos[i] = randomPos();
        //    Instantiate(pickup, new Vector3(pickupPos[i].x, pickupPos[i].y, 0), Quaternion.identity);
        //}

        Spawn();

    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpCount < 20) {
            Vector2 tmp = randomPos();
            Instantiate(pickup, new Vector3(tmp.x, tmp.y, 0), Quaternion.identity);
            pickUpCount += 1;
        }
    }
    public static Vector2 randomPos()
    {

        var x = Random.Range(-38, 38);
        var y = Random.Range(-12, 12);

        return new Vector2(x, y);
    }
    public void Spawn() {
        for (int i = 0; i < pickUpCount; i++)
        {
            Vector2 tmp = randomPos();
            Instantiate(pickup, new Vector3(tmp.x, tmp.y, 0), Quaternion.identity);
        }
    }
}
