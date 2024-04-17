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
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
        timeLeft -= Time.deltaTime;
    }
}
