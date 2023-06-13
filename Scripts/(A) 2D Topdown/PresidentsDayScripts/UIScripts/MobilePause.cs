using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobilePause : MonoBehaviour
{

    public bool menuOn = false;

    public void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        menuOn = false;
        GetComponent<Canvas>().enabled = false;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Pause()
    {
        if (menuOn == false)
        {
            Time.timeScale = 0;
            menuOn = true;
            GetComponent<Canvas>().enabled = true;
        }
        else if (menuOn == true)
        {
            Time.timeScale = 1;
            menuOn = false;
            GetComponent<Canvas>().enabled = false;
        }
    }
    public void Continue(Canvas messageCanvas)
    {
        messageCanvas.enabled = false;
        GameObject.Find("UI/HUD").GetComponent<Canvas>().enabled = true;
    }
    public void Quit() { Application.Quit(); }
}
