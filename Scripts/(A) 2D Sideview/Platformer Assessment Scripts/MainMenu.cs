using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        GameObject.Find("Level Changer").GetComponent<LevelChanger>().FadeToNextLevel();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Select");
        GetComponent<Canvas>().enabled = false;
    }
    public void ContinueGame(int buildIndex)
    {
        GameObject.Find("Level Changer").GetComponent<LevelChanger>().FadeToLastLevel(buildIndex);
    }
}
