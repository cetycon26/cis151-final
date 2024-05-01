using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public GameObject note1;
    public GameObject note2;
    public GameObject note3;

    AudioSource src;
	public AudioClip noteSound;

    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitNote1(){
        note1.SetActive(false);
        src.PlayOneShot(noteSound);
    }
    public void ExitNote2(){
        note2.SetActive(false);
        src.PlayOneShot(noteSound);
    }
    public void ExitNote3(){
        note3.SetActive(false);
        src.PlayOneShot(noteSound);
    }
}
