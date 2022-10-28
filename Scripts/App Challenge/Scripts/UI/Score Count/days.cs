using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class days : MonoBehaviour
{
    TextMeshProUGUI text;
    public int dayCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        dayCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dayCount = SceneLoader.day;
        text.text = ("Day " + dayCount);
    }
}
