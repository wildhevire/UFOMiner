using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int enemyCount = 2;
    [SerializeField] int count = 2;
    [SerializeField] GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = count;
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 tmp = PickupsSpawner.RandomPos();
            
            Instantiate(enemyPrefab, new Vector3(tmp.x, tmp.y, 0), Quaternion.identity, this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
