using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class ParalysisAI : MonoBehaviour
{
    // GameObject player;
    public bool inView;
    public static bool inRoom;
    public bool lookedAtOnce;
    
    public int random;
    public AudioClip respawnSound;
    AudioSource src;

    public Vector3 outside = new Vector3(4.17f, 2.32f, 28.2f);
    public float respawnTimer = 10;

    public static float stareTime;
    public static float paralyzedTime = 3;
    public static bool isParalyzed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        src = GetComponent<AudioSource>();
        src.PlayOneShot(respawnSound);

        stareTime = 3;
        inRoom = true;
        lookedAtOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        //If Paralysis gets too close behind, Paralyze player
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        // Debug.Log("Paralysis dist: " + distance);
        if (distance < 3)
        {
            ParalyzePlayer();
        }
    }
    void FixedUpdate()
    {
        if (!lookedAtOnce) //If not spotted, gets closer to you
        {
            transform.position -= transform.forward * Time.deltaTime; // It's -= because of flipping the FacePlayer y-axis (180 * ...)
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
        else if (lookedAtOnce && !inView) //If spotted but gaze averted, despawn
        {
            inRoom = false;
            Destroy(this.gameObject);
        }
    }
    

    void ParalyzePlayer()
    {
        isParalyzed = true;
        paralyzedTime -= Time.deltaTime;
        if (paralyzedTime > 0)
        {
            BodyController.lookSpeed = 0f;
            CameraController.lookSpeed = 0f;
        } 
        if (paralyzedTime <= 0) {
            stareTime = 3;
            paralyzedTime = 3;
            BodyController.lookSpeed = 1.0f;
            CameraController.lookSpeed = 1.0f;
            
            isParalyzed = false;

            inRoom = false;
            Destroy(this.gameObject);
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
}
