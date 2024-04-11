using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalysisAI : MonoBehaviour
{
    public GameObject player;
    public bool inView;
    public bool inRoom;
    public bool lookedAtOnce;

    public int random;

    public Vector3 outside = new Vector3(4.17f, 2.32f, 28.2f);
    public float respawnTimer = 10;

    public float stareTime = 15;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(8.35f, 2.32f, 7.8f);
        inView = false;
        inRoom = true;
        lookedAtOnce = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!inView && lookedAtOnce)
        {
            transform.position += transform.forward * Time.deltaTime;
        }
        else if (inView && lookedAtOnce) 
        {
            if (stareTime > 0)
            {
                stareTime -= Time.deltaTime;
            }
            else
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                transform.position = outside;
                stareTime = 3;
                inRoom = false;
                lookedAtOnce = false;
            }
        }
        else if (!inRoom)
        {
            reSpawn();
        }
    }
    
    void OnBecameVisible()
    {
        inView = true;
        lookedAtOnce = true;
    }

    void OnBecameInvisible()
    {
        inView = false;
    }
    
    void reSpawn()
    {
        respawnTimer -= Time.deltaTime;
        if (respawnTimer < 0)
        {
            random = Random.Range(1, 4);
            if (random == 1)
            {
                transform.position = new Vector3(Random.Range(-8.35f, 8.35f), 2.32f, 7.8f);
            }
            else if (random == 2)
            {
                transform.position = new Vector3(Random.Range(-8.35f, 8.35f), 2.32f, -7.8f);
            }
            else if(random == 3)
            {
                transform.position = new Vector3(-8.35f, 2.32f, Random.Range(-7.8f, 7.8f));
            }
            else
            {
                transform.position = new Vector3(8.35f, 2.32f, Random.Range(-7.8f, 7.8f));
            }
            gameObject.GetComponent<Renderer>().enabled = true;
            respawnTimer = Random.Range(7, 12);
            inRoom = true;
        }
    }
}
