using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudio : MonoBehaviour
{
    public AudioClip breathing;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = breathing;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameData.isAtDoor1 && GameData.enemyAtDoor1)
        {
            if (!GameData.playingBreathing)
            {

                source.Play(0);
                GameData.playingBreathing = true;
            }
        }
        else if (GameData.isAtDoor2 && GameData.enemyAtDoor2)
        {
            if (!GameData.playingBreathing)
            {

                source.Play(0);
                GameData.playingBreathing = true;
            }
        }
        else
        {
            source.Pause();
            GameData.playingBreathing = false;
        }
    }
}
