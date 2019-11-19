using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsSpawner : MonoBehaviour
{
   
   // public static List<GameObject> pickupPos;
    //Vector2[] pickupPos;
    public static int pickUpCount = 20;
    [SerializeField] GameObject pickup;


    private void Awake()
    {

        for (int i = 0; i < pickUpCount; i++)
        {
            SpawnRandom(pickup, this.transform);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpCount < 20) {
            SpawnRandom(pickup, this.transform);
            pickUpCount += 1;
        }
    }
    public static Vector2 RandomPos()
    {

        var x = Random.Range(-38, 38);
        var y = Random.Range(-12, 12);

        return new Vector2(x, y);
    }
    public static void SpawnRandom(GameObject pickup, Transform parent) {
        
        
            Vector2 tmp = RandomPos();
            Instantiate(pickup, new Vector3(tmp.x, tmp.y, 0), Quaternion.identity, parent);
        
    }
}
