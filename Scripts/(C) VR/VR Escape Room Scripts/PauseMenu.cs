using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas can;
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

        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            //Cursor.visible = true;
            can.enabled = true;
            Time.timeScale = 0f;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(menuOpen);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            Resume();
        }

    }

    public void Resume()
    {
        //Cursor.visible = false;
        Time.timeScale = 1;
        can.enabled = false;
        areYouSure.enabled = false;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(menuClose);
        //Camera.main.GetComponent<AudioSource>().PlayOneShot(menuClose);
    }

    public void ExitGame()
    {
        //FindObjectOfType<SceneLoader>().QuitGame();
    }

    public void LoadMainMenu()
    {
        //Time.timeScale = 1;
        AreYouSure();
    }
    public void AreYouSure()
    {
        Time.timeScale = 0;
        areYouSure.enabled = true;
    }
    public void Sure()
    {
        Time.timeScale = 1;
        //FindObjectOfType<SceneLoader>().LoadMenu();
    }
    public void NotSure()
    {
        areYouSure.enabled = false;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(menuClose);
    }
}
