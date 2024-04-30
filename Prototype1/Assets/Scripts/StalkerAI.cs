using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerAI : MonoBehaviour
{
    public GameObject player;
    public bool inView;
    public static bool inRoom;
    public bool lookedAtOnce;

    public int random;
    public AudioClip respawnSound;
    AudioSource src;

    public Vector3 outside = new Vector3(4.17f, 2.32f, 28.2f);
    public float respawnTimer = 10;

    public static float stareTime;
    
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        src = GetComponent<AudioSource>();
        // src.PlayOneShot(respawnSound);
        stareTime = 5;
        inRoom = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Send player to DeathScene if Stalker gets too close
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        // Debug.Log("Stalker dist: " + distance);
        if (distance < 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("StalkerDeath");
        }
    }

    void FixedUpdate()
    {
        // Move forward if not in view
        if (!inView)
        {
            transform.position -= transform.forward * Time.deltaTime; // It's -= because of flipping the FacePlayer y-axis (180 * ...
        } 
        else
        {
            if (stareTime > 0)
            {
                stareTime -= Time.deltaTime;
            }
            else
            {
                inRoom = false;
                Destroy(this.gameObject);
            }
        }
    }
    
    void OnBecameVisible()
    {
        inView = true;
    }

    void OnBecameInvisible()
    {
        inView = false;
    }
    

}
