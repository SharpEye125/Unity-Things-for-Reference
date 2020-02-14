using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int level = 3;
    public int health = 40;
    public Text healthText;
    public Text levelText;

    void Start()
    {
        UpdateText();
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        UpdateText();
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        UpdateText();
    }
    public void UpdateText()
    {
        healthText.text = "Health: " + health;
        levelText.text = "Level: " + level;
    }
    public void PlusHealth()
    {
        health++;
        UpdateText();
    }
    public void MinusHealth()
    {
        health--;
        UpdateText();
    }
    public void PlusLevel()
    {
        level++;
        UpdateText();
    }
    public void MinusLevel()
    {
        level--;
        UpdateText();
    }
}
