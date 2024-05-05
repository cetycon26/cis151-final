using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controlsMenu;
    public GameObject levelMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        // UnityEngine.SceneManagement.SceneManager.LoadScene("Level1-Bedroom");
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void Level1() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1-Bedroom");
    }

    public void Level2() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Hallway");
    }

    public void Level3() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
    }

    public void Controls(){
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void Back(){
        mainMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void BackLevel() {
        levelMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
