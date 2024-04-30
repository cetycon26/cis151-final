using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    bool pmenu;

    // Start is called before the first frame update
    void Start()
    {
        pmenu = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!pmenu) {
                PauseFunction();

            }
            else {
                Resume();
            }
            
        }
    }

    public void Resume(){
        pmenu = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);

    }

    public void GoToMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void PauseFunction(){
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pmenu = true;
    }

}
