using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int level;
    public int health = 40;

    void Start()
    {
        LoadPlayer();
    }
    private void Update()
    {
        health = GetComponent<PlayerHealth>().health;
    }
    public void SavePlayer(int buildIndex)
    {
        LevelToIndex(buildIndex);
        SaveSystem.SavePlayer(this);

    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        //Vector3 position;
        //position.x = data.position[0];
        //position.y = data.position[1];
        //position.z = data.position[2];
        //transform.position = position;

    }
    public void LevelToIndex(int buildIndex)
    {
        level = SceneManager.GetActiveScene().buildIndex;
    }
    public void HealthToHealth()
    {
        health = GetComponent<PlayerHealth>().health;
    }
}
