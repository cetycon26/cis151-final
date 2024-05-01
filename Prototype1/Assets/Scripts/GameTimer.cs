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
	public float totalMin;
	int currHour;
	int currMinute;

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
   	 
		if (GameData.level == 1) {
			clockText.text = "6:00";
			currHour = 6;
			currMinute = 0;
		}
		else if (GameData.level == 2) {
			clockText.text = "8:00";
			currHour = 8;
			currMinute = 0;
		}
		else {
			clockText.text = "10:00";
			currHour = 10;
			currMinute = 0;
		}
    	totalMin = 0;

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
			GameData.level += 1;
			GameData.enemyAtDoor1 = false;
    		GameData.enemyAtDoor2 = false;
			GameData.lvl2enemySpawned = false;
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
				clockText.text = currHour + ":" + currMinute + currMinute;
        	}
        	else
        	{
            	currMinute += 10;
				clockText.text = currHour + ":" + currMinute;
        	}
        	timePassed = 0;
			totalMin += 10;
        	
			
    	}
	if (!note1active) {
		if (totalMin >= 30) {
			note1.SetActive(true);
			note1active = true;
			src.PlayOneShot(noteSound);
		}
	}
	else if (!note2active) {
		if (totalMin >= 60) {
			note2.SetActive(true);
			note2active = true;
			src.PlayOneShot(noteSound);
		}
	}
	else if (!note3active) {
		if (totalMin >= 90) {
			note3.SetActive(true);
			note3active = true;
			src.PlayOneShot(noteSound);
		}
	}
			
	}
}


