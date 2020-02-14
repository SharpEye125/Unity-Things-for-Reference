using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    public GameObject area1To2Gate1;
    public GameObject area1To2Gate2;
    public bool justWarped = false;
    float delay = 1.1f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "RightWarp" && justWarped == false)
        {
            transform.position = area1To2Gate2.transform.position;
            justWarped = true;
            timer = 0;
        }
        if (collision.gameObject.tag == "LeftWarp" && justWarped == false)
        {
            transform.position = area1To2Gate1.transform.position;
            justWarped = true;
            timer = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (timer > delay)
        {
            justWarped = false;
        }
    }
}
