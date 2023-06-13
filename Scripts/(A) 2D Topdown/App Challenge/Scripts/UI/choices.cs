using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choices : MonoBehaviour
{
    public Text text;
    public Text textscore;
  
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        text.text = ("You worked ")+ (Singleton.wwent) + (" times                ") + ("You rested ")+(Singleton.rwent) + (" times                     ") + ("You had fun ") + (Singleton.fwent) + (" times  ");



        textscore.text = ("You got a score of ") + ((SceneLoader.day) * (Singleton.gemsgot) + (Singleton.ribsgot * 2)) ;
    }
}