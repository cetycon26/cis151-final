using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float timeLeft;
    public string nextScene;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
