using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controlsMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1-Bedroom");
    }

    public void Controls(){
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void Back(){
        mainMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }
}
