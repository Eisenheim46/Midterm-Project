using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreen : MonoBehaviour {


    public void playButton()
    {
        SceneManager.LoadScene(1);
    }

    public void creditsButton()
    {
        SceneManager.LoadScene(4);
    }

    public void menuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void controlsButton()
    {
        SceneManager.LoadScene(5);
    }
}
