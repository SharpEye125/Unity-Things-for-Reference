using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelTransitions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Level 2")
        {
            SceneManager.LoadScene("Level 2");
        }
        else if
            (collision.gameObject.tag == "Level 3")
        {
            SceneManager.LoadScene("Level 3");
        }
        else if
            (collision.gameObject.tag == "Win")
            {
                SceneManager.LoadScene("Win");
            }
    }
}
