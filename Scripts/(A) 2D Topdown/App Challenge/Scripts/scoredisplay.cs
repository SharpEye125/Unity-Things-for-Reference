using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoredisplay : MonoBehaviour
{
    public Text text;
    public string tring;




    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
      
        text.text = ("You collected                   ") +(Singleton.gemsgot) +(" gems                ") + (Singleton.ribsgot) +(" ribbons");
    }
}