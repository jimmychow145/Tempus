using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int enemyCount = 100;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemy, new Vector3(Random.Range(10f, 990f), 20, Random.Range(10f, 990f)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
