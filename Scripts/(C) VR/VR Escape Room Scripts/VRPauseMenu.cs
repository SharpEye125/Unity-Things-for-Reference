using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRPauseMenu : MonoBehaviour
{
    [SerializeField] Canvas can;
    bool isPaused = false;
    public Canvas areYouSure;
    public AudioClip menuOpen;
    public AudioClip menuClose;

    // Use this for initialization
    void Start()
    {
        can.enabled = false;
        areYouSure.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            //Cursor.visible = true;
            can.enabled = true;
            isPaused = true;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(menuOpen);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            Resume();
        }

    }

    public void Resume()
    {
        //Cursor.visible = false;
        isPaused = false;
        can.enabled = false;
        areYouSure.enabled = false;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(menuClose);
        //Camera.main.GetComponent<AudioSource>().PlayOneShot(menuClose);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        //Time.timeScale = 1;
        AreYouSure();
    }
    public void AreYouSure()
    {
        areYouSure.enabled = true;
    }
    public void Sure()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void NotSure()
    {
        areYouSure.enabled = false;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(menuClose);
    }
}
