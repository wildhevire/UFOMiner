using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int enemyCount = 2;
    public  float minForce= 5;
    public  float maxForce= 30;
    [SerializeField] int count = 2;
    [SerializeField] GameObject enemyPrefab;

    public enum Difficulties
    {
        Easy, Hard
    }
    public  Difficulties difficulty = Difficulties.Easy;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = count;
        for (int i = 0; i < enemyCount; i++)
        {
            PickupsSpawner.SpawnRandom(enemyPrefab, this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
