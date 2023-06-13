using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float levelTime = 120.0f;
    //float timer = 0;
    public Text TimeText;

    // Update is called once per frame
    void Update()
    {
        TimeText.text = "Time: " + levelTime; //+ "/" + levelTime;
        levelTime -= Time.deltaTime;
        if(levelTime < 0)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name);
            //SceneManager.LoadScene("Lose");
        }
    }
}
