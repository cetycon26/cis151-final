using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2EnemySpawner : MonoBehaviour
{

    public GameObject doorEnemy1;
    public GameObject doorEnemy2;
    public GameObject windowEnemy;

    public float minSpawnTime = 5.0f;
    public float maxSpawnTime = 10.0f;
    public float spawnTime = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameData.lvl2enemySpawned)
        {
            spawnTime = spawnTime - Time.deltaTime;
        }
        if (spawnTime <= 0)
        {
            GameData.lvl2enemySpawned = true;
            int spawnNum = Random.Range(0, 4);
            if (spawnNum == 0)
            {
                // WINDOW
                //var pos = new Vector3(0f, 5f, -12f); // window
                GameData.enemyAtDoor1 = true;
                var pos = new Vector3(-20f, 2.13f, 2.4f); // door 1 hallway
                Instantiate(windowEnemy, pos, Quaternion.identity);
            }
            else if (spawnNum <= 2) 
            {
                // DOOR 1

                GameData.enemyAtDoor1 = true;
                var pos = new Vector3(-20f, 2.13f, 2.4f); // door 1 hallway
                Instantiate(doorEnemy1, pos, Quaternion.identity);
            }
            else
            {
                // DOOR 2

                GameData.enemyAtDoor2 = true;
                var pos = new Vector3(20f, 2.13f, -4); // door 2 hallway
                Instantiate(doorEnemy2, pos, Quaternion.identity);
            }

            spawnTime = Random.Range(5.0f, 10.0f);
        }
    }
}
