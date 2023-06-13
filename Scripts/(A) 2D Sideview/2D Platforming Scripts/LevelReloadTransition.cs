using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReloadTransition : MonoBehaviour
{
    public int levels;
    // Start is called before the first frame update
    void Start()
    {
        levels = PlayerPrefs.GetInt("levels");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Reload")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.gameObject.tag == "NextLevel")
        {
            levels++;
            PlayerPrefs.SetInt("levels", levels);
            switch (levels)
            {
                case 1:
                    SceneManager.LoadScene("Level 2");
                    break;
                case 2:
                    SceneManager.LoadScene("Level 1");
                    break;
                default:
                    levels = 0;
                    PlayerPrefs.SetInt("levels", levels);
                    break;
            }
        }
    }
}
