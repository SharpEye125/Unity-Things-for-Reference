using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool playedTutorial;
    public GameObject skipTutorial;
    int lastLevel;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Canvas>().enabled = true;
        lastLevel = PlayerPrefs.GetInt("lastLevel");
        if (lastLevel == 1)
        {
            playedTutorial = true;
        }
    }
    public void StartGame()
    {
        if (playedTutorial == false)
        {
            skipTutorial.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            SceneManager.LoadScene("Arena");
        }
    }
    public void SkipTutorial()
    {
        SceneManager.LoadScene("Arena");
    }
    public void Tutorial()
    {
        PlayerPrefs.SetInt("lastLevel", 1);
        SceneManager.LoadScene("Tutorial");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void DontSkipTutorial()
    {
        PlayerPrefs.SetInt("lastLevel", 1);
        SceneManager.LoadScene("Tutorial");
    }
    public void Cancel()
    {
        skipTutorial.GetComponent<Canvas>().enabled = false;
    }

}
