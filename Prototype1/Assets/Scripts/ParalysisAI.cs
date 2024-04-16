using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParalysisAI : MonoBehaviour
{
    public GameObject player;
    public bool inView;
    public bool inRoom;
    public bool lookedAtOnce;
// Hi
    public int random;
    public AudioClip respawnSound;
    AudioSource src;

    public Vector3 outside = new Vector3(4.17f, 2.32f, 28.2f);
    public float respawnTimer = 10;

    public float stareTime;
    public float paralyzedTime = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = new Vector3(8.35f, 2.32f, 7.8f);
        inView = false;
        inRoom = true;
        lookedAtOnce = false;
        reSpawn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!lookedAtOnce) //If not spotted, gets closer to you
        {
            transform.position += 2 * transform.forward * Time.deltaTime;
        }

        if (lookedAtOnce && inView) //If spotted and in view
        {
            if (stareTime > 0) //Staring timer
            {
                stareTime -= Time.deltaTime;
            } else { //Paralyze
                ParalyzePlayer();
            }
        }
        else if (lookedAtOnce && !inView) //If gaze averted, despawn
        {

            gameObject.GetComponent<Renderer>().enabled = false;
            transform.position = outside;
            stareTime = 3;
            inRoom = false;
            lookedAtOnce = false;
        }
        else if (!inRoom)
        {
            //  ParalyzePlayer(); 
            reSpawn();
        }
    }
    

    void ParalyzePlayer()
    {
        paralyzedTime -= Time.deltaTime;
        if (paralyzedTime > 0)
        {
            BodyController.lookSpeed = 0f;
            CameraController.lookSpeed = 0f;
        } 
        if (paralyzedTime <= 0) {
            stareTime = 3;
            paralyzedTime = 5;
            BodyController.lookSpeed = 1.0f;
            CameraController.lookSpeed = 1.0f;

            gameObject.GetComponent<Renderer>().enabled = false;
                transform.position = outside;
                stareTime = 3;
                inRoom = false;
                lookedAtOnce = false;
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
            src.PlayOneShot(respawnSound);
        }
    }
}
