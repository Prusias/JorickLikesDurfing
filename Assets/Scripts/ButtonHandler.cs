using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject resume;
    public int timesPressed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            resume.SetActive(true);
            timesPressed += 1;
        } else if (timesPressed == 2)
        {
            Time.timeScale = 1;
            resume.SetActive(false);
            timesPressed = 0;
        }

    }
    public void Play()
    {
        Loader.Load(Loader.Scene.MainGame);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
            Loader.Load(Loader.Scene.StartScreen); 
    }
}
