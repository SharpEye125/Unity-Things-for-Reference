using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public int powerUp;
    //public float timer = 0f;
    public float powerUpTimer = 10f;
    public bool hasPowerUp = false;
    public Text powerUpTimeLeft;
    public Image Bounce;
    public Image Tracking;
    // Start is called before the first frame update
    void Start()
    {
        DisablePowerUpUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPowerUp == true)
        {
            powerUpTimeLeft.enabled = true;
            //timer += Time.deltaTime;
            powerUpTimeLeft.text = ("" + powerUpTimer);
            if (powerUpTimer <= 0)
            {
                hasPowerUp = false;
                powerUp = 0;
                powerUpTimer = 10;

                DisablePowerUpUI();
                UpdatePowerUps();
            }
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("PowerUp1"))
        {
            powerUp = 1;
            CollectingPowerUp();
            //This one is irrelevant atm
        }

        if (collision.tag == ("PowerUp2"))
        {
            StopCoroutine("PowerUpTime");
            powerUp = 2;
            CollectingPowerUp();
            Destroy(collision.gameObject);
            Bounce.enabled = true;
            StartCoroutine("PowerUpTime");
        }

        if (collision.tag == ("PowerUp3"))
        {
            StopCoroutine("PowerUpTime");
            powerUp = 3;
            CollectingPowerUp();
            Destroy(collision.gameObject);
            Tracking.enabled = true;
            StartCoroutine("PowerUpTime");
        }

        UpdatePowerUps();
    }

    IEnumerator PowerUpTime() //This is the Coroutine
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            powerUpTimer--;
        }

    }

    void UpdatePowerUps()
    {
        GetComponent<ShootingScript>().powerUps = powerUp;
    }
    void CollectingPowerUp()
    {
        hasPowerUp = true;
        powerUpTimer = 10;
        
    }
    void DisablePowerUpUI()
    {
        powerUpTimeLeft.enabled = false;
        Tracking.enabled = false;
        Bounce.enabled = false;
        StopCoroutine("PowerUpTime");
    }
}
