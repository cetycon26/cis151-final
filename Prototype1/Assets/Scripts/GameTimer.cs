using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
	public float timeLeft;
	public string nextScene;
	public TMP_Text clockText;
	public float timePassed = 0;
	int currHour = 9;
	int currMinute = 0;

	public GameObject note1;
    public GameObject note2;
    public GameObject note3;

	bool note1active;
	bool note2active;
	bool note3active;

	AudioSource src;
	public AudioClip noteSound;

    
	// Start is called before the first frame update
	void Start()
	{
   	 
    	clockText.text = "9:00";
		note1active = false;
		note2active = false;
		note3active = false;
		src = GetComponent<AudioSource>();
	}

	void FixedUpdate()
	{
    	if (timeLeft <= 0)
    	{
        	BodyController.lookSpeed = 1.0f;
        	CameraController.lookSpeed = 1.0f;
        	UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    	}
    	timeLeft -= Time.deltaTime;
    	timePassed += Time.deltaTime;
    	if (timePassed >= 10)
    	{
        	if (currMinute == 50)
        	{
            	currHour += 1;
            	currMinute = 0;
        	}
        	else
        	{
            	currMinute += 10;
        	}
        	timePassed = 0;
        	clockText.text = currHour + ":" + currMinute;
    	}
	if (!note1active) {
		if (currHour == 9 && currMinute >= 30) {
			note1.SetActive(true);
			note1active = true;
			src.PlayOneShot(noteSound);
		}
	}
	else if (!note2active) {
		if (currHour == 10 && currMinute >= 0) {
			note2.SetActive(true);
			note2active = true;
			src.PlayOneShot(noteSound);
		}
	}
	else if (!note3active) {
		if (currHour == 10 && currMinute >= 30) {
			note3.SetActive(true);
			note3active = true;
			src.PlayOneShot(noteSound);
		}
	}
			
	}
}


