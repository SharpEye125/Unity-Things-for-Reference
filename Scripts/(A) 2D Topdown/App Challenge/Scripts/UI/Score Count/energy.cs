using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energy : MonoBehaviour
{
    Text text;
    public int scoreAmount = 0;



    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        scoreAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreAmount = Mathf.RoundToInt(Singleton.energy);
        text.text = ("Energy " + scoreAmount.ToString());
    }
}
