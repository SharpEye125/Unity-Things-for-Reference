using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToWin : MonoBehaviour
{
    public int Acorn = 0;
    public Text acornText;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Acorn")
        {
            Acorn++;
            Destroy(collision.gameObject);
            acornText.text = "Acorns: " + Acorn;
            if (Acorn > 9)
            {
                
                if ( Acorn == 10)
                {
                    SceneManager.LoadScene("Level 2");
                    
                }
                else if (Acorn >= 15)
                {
                    SceneManager.LoadScene("Win");
                }
            }
        }
    }
}
