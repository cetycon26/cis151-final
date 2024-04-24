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

    
	// Start is called before the first frame update
	void Start()
	{
   	 
    	clockText.text = "9:00";
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
	}
}


