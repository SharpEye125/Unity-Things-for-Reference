using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimeLimit : MonoBehaviour
{
    public float timer = 0f;
    public float timeLimit = 30f;
    //bool gameOver = false;
    public GameObject clockHand;
    public float timerRotationSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        if(Singleton.half == true)
        {
            timerRotationSpeed = timerRotationSpeed * 2.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= timeLimit)
        {
            //timerRotation
            clockHand.transform.eulerAngles = new Vector3(0, 0, timer * -timerRotationSpeed);
        }
        
        if (Time.timeScale != 0)
        {
            timer += Time.deltaTime;
            
        }

    }
}
