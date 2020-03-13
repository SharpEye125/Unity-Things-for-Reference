using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public string moneyDisplay = "Money: ";
    public int playerMoney = 0;
    public Text moneyText;

    public int health = 10;
    public int maxHealth;
    public string healthDisplay = "Health: ";
    //public Text healthText;
    public Slider healthSlider;
    public float continuousContact = 1;
    float contactTimer = 0.0f;
    bool contact;
    int lastMoney;


    void Start()
    {
        //if (healthText == null)
        //{
        //    Debug.LogError("No health text set to Player");
        //}
        maxHealth = health;
        //healthText.text = healthDisplay + health;
        healthSlider.maxValue = health;
        healthSlider.value = health;
        moneyText.text = moneyDisplay + playerMoney;


    }
    void Update()
    {
        if (playerMoney != lastMoney)
        {
            moneyText.text = moneyDisplay + playerMoney;
        }
        if (contact == true)
        {
            contactTimer += Time.deltaTime;
        }
        else
        {
            contactTimer = 0.0f;
        }   
        lastMoney = playerMoney;
    }
    //Enemy Contact
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !contact)
        {
            health--;
            UpdateHP();
            if (health < 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene("Lose");
            }
        }
    }
    //Damages you if you stay in contact
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            contact = true;
            if (contactTimer >= continuousContact)
            {
                contactTimer = 0;
                health--;
                UpdateHP();
                if (health < 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    //SceneManager.LoadScene("Lose");
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            contact = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Plus Health
        if (collision.gameObject.tag == "Health")
        {
            if (health < maxHealth)
            {
                health++;
                Destroy(collision.gameObject);
                UpdateHP();
            }
        }
        //Enemy Bullets
        if (collision.tag == "EnemyBullet")
        {
            health--;
            UpdateHP();
            if (health < 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene("Lose");
            }
        }
    }
    public void UpdateHP()
    {
        //healthText.text = healthDisplay + health;
        healthSlider.value = health;
    }
}
