using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public string nextscene;
    
    // Start is called before the first frame update
    void Start()
    {
        CameraController.lookSpeed = 1.0f;
        BodyController.lookSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextscene);
        }
    }
}
