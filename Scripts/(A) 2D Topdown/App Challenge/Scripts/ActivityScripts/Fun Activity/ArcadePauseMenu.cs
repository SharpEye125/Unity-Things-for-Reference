using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArcadePauseMenu : MonoBehaviour
{
    public AudioClip menuOpen;
    public AudioClip menuClose;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                GetComponent<AudioSource>().Pause();
                GetComponent<Canvas>().enabled = true;
                Time.timeScale = 0;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(menuOpen);
            }
            else
            {
                GetComponent<AudioSource>().UnPause();
                GetComponent<Canvas>().enabled = false;
                Time.timeScale = 1;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(menuClose);
            }
        }
    }
}
