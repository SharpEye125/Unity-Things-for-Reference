using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu2 : MonoBehaviour
{
    int level;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        level = SceneManager.GetActiveScene().buildIndex;
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                GetComponent<Canvas>().enabled = true;
                Time.timeScale = 0;
            }
            else
            {
                GetComponent<Canvas>().enabled = false;
                Time.timeScale = 1;
            }
        }
    }
    public void LoadMainMenu()
    {
        PlayerPrefs.SetInt("lastLevel", level);
        SceneManager.LoadScene("Main Menu");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        PlayerPrefs.SetInt("lastLevel", level);
        Application.Quit();
    }
    public void OpenOrCloseMenu()
    {
        if (Time.timeScale == 1)
        {
            GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
        else
        {
            GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
        }
    }
}
