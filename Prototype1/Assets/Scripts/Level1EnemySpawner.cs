using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1EnemySpawner : MonoBehaviour
{
    public GameObject paralysis;
    public GameObject stalker;
    public float paralysisRespawnTime = 15.0f;
    public float stalkerRespawnTime = 5.0f;

    int random;

    void Start()
    {
        ParalysisAI.inRoom = false;
        StalkerAI.inRoom = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // GameObject stalker = GameObject.FindGameObjectWithTag("Stalker");

        if (!ParalysisAI.inRoom){
        paralysisRespawnTime = paralysisRespawnTime - Time.fixedDeltaTime;
        } else {
            paralysisRespawnTime = Random.Range(13, 20);
        }
        if (!StalkerAI.inRoom){
        stalkerRespawnTime = stalkerRespawnTime - Time.fixedDeltaTime;
        } else {
            stalkerRespawnTime = Random.Range(5, 10);
        }
        
        // GameObject goStalker = null;

        // Paralysis respawn
        if (paralysisRespawnTime <= 0) {

            //Choose 1 of 4 random possible spawn spots in Bedroom
            random = Random.Range(1, 4);
            if (random == 1)
            {
                var pos = new Vector3(Random.Range(-8.35f, 8.35f), 2.32f, 7.8f);
                var go = Instantiate(paralysis, pos, Quaternion.identity);
                // ParalysisAI.inRoom = true;
            }
            else if (random == 2)
            {
                var pos = new Vector3(Random.Range(-8.35f, 8.35f), 2.32f, -7.8f);
                var go = Instantiate(paralysis, pos, Quaternion.identity);
                // ParalysisAI.inRoom = true;
            }
            else if(random == 3)
            {
                var pos = new Vector3(-8.35f, 2.32f, Random.Range(-7.8f, 7.8f));
                var go = Instantiate(paralysis, pos, Quaternion.identity);
                // ParalysisAI.inRoom = true;
            }
            else //Respawn Location #4
            {
                var pos = new Vector3(8.35f, 2.32f, Random.Range(-7.8f, 7.8f));
                var go = Instantiate(paralysis, pos, Quaternion.identity);
                // ParalysisAI.inRoom = true;
            }            
            
        }

        // Stalker respawn
        if (stalkerRespawnTime <= 0) {
                        
                //Choose 1 of 4 random possible spawn spots in Bedroom
                random = Random.Range(1, 4);
                if (random == 1)
                {
                    var pos = new Vector3(Random.Range(-8.35f, 8.35f), 1.35f, 7.8f);
                    var goStalker = Instantiate(stalker, pos, Quaternion.identity);
                }
                else if (random == 2)
                {
                    var pos = new Vector3(Random.Range(-8.35f, 8.35f), 1.35f, -7.8f);
                    var goStalker = Instantiate(stalker, pos, Quaternion.identity);
                }
                else if(random == 3)
                {
                    var pos = new Vector3(-8.35f, 1.35f, Random.Range(-7.8f, 7.8f));
                    var goStalker = Instantiate(stalker, pos, Quaternion.identity);
                }
                else //Respawn Location #4
                {
                    var pos = new Vector3(8.35f, 1.35f, Random.Range(-7.8f, 7.8f));
                    var goStalker = Instantiate(stalker, pos, Quaternion.identity);
                }         
        }
    }
}

