using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Button_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

    // Update is called once per frame
    public void Button_Pause()
    {
        if (Time.timeScale != 0)
            Time.timeScale = 0;
        else Time.timeScale = 1;
    }
    public void Button_UnPause()
    {
        Time.timeScale = 1;
    }
}
