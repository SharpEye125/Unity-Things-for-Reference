using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayDisplay : MonoBehaviour
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
      if(Singleton.stressloss==true)
        {
            tring = ("stress");
        }
        if (Singleton.energyloss == true)
        {
            tring = ("exhaustion");
        }
        if(Singleton.moneyloss == true)
        {
            tring = ("being worried about getting kicked out from your apartment");
        }
        text.text = ("You got by for " +SceneLoader.day.ToString() +" days " + "before passing out due to "+tring );
    }
}
