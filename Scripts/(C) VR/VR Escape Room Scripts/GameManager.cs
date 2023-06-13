using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Timer Components")]
    [SerializeField] private float gameTime;
    [SerializeField] Text timeTextBox;

    [Header("Timer Events")]
    public UnityEvent onTimerExpire;

    private bool allowTimer;

    enum GameState
    {
        Waiting,
        Playing,
        Completed,
        End
    }
    private GameState gamestate;


    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PuzzleManager>().stage == 1)
        {
            allowTimer = true;
            gamestate = GameState.Playing;
        }

        if (allowTimer)
            UpdateGameTimer();

        if(gamestate == GameState.Playing)
            CheckTime();
    }

    private void CheckTime()
    {
        if(gameTime <= 0)
        {
            allowTimer = false;

            timeTextBox.text = "Loser";

            onTimerExpire.Invoke();

            gamestate = GameState.End;
        }
    }

    private void UpdateGameTimer()
    {
        gameTime -= Time.deltaTime;

        var minutes = Mathf.FloorToInt(gameTime / 60);
        var seconds = Mathf.FloorToInt(gameTime - minutes * 60);

        string gameTimeClockDisplay = string.Format("{0:0}:{1:00}", minutes, seconds);

        timeTextBox.text = gameTimeClockDisplay;
    }

    public void RoomComplete()
    {
        timeTextBox.text = "Success";
        allowTimer = false;
        gamestate = GameState.Completed;
    }
}
