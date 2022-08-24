using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{

    public void StartPressed()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }
    public void MenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Level1Pressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
}
