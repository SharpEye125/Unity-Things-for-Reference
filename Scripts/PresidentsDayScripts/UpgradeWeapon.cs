using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWeapon : MonoBehaviour
{
    WeaponRotation bulletStats;
    PlayerHP playerHPThings;
    Transform playerGun;
    Transform player;
    [Header("Upgrades")]
    public float shootDelayDecrease = 0.1f;
    public float bulletSpeedIncrease = 1f;
    //public int bulletCountIncrease = 1;
    public int maxHealthIncrease = 1;

    [Header("Upgrade Prices")]
    public int shootDelayPrice = 10;
    public int bulletSpeedPrice = 10;
    //public int bulletCountPrice = 20;
    public int maxHealthPrice = 30;
    public int pricesInceases = 5;
    [Header("UI things")]
    public Text shootDelayText;
    public Text bulletSpeedText;
    //public Text bulletCountText;
    public Text maxHealthText;
    [Header("Optional")]
    public bool maxUpgradeLevels = false;
    public int maxBulletSpeedLevel;
    public int maxMaxHealthLevel;

    int shootDelayLevel = 0;
    int bulletSpeedLevel = 0;
    //int bulletCountLevel = 0;
    int maxHealthLevel = 0;
    GameObject disableFS;
    GameObject disableBS;
    GameObject disableMH;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
        playerGun = GameObject.FindGameObjectWithTag("Gun").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHPThings = player.GetComponent<PlayerHP>();
        bulletStats = playerGun.GetComponent<WeaponRotation>();
        disableFS = GameObject.Find("Fire Speed");
        disableBS = GameObject.Find("Bullet Speed");
        disableMH = GameObject.Find("Max Health");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCloseUpgradeStore()
    {
        if (GetComponent<Canvas>().enabled == false)
        {
            UpdateUI();
            GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
        else
        {
            GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
        }
    }

    public void UpgradeFireSpeed()
    {
        if (playerHPThings.playerMoney >= shootDelayPrice)
        {
            playerHPThings.playerMoney -= shootDelayPrice;
            shootDelayPrice += pricesInceases % 100;
            bulletStats.shootDelay -= shootDelayDecrease;
            shootDelayLevel++;
            UpdateUI();
            if (bulletStats.shootDelay <= 0.01)
            {
                bulletStats.shootDelay = 0.05f;
                disableFS.GetComponent<Button>().interactable = false;
            }
        }
    }
    public void UpgradeBulletSpeed()
    {
        if (playerHPThings.playerMoney >= bulletSpeedPrice)
        {
            playerHPThings.playerMoney -= bulletSpeedPrice;
            bulletSpeedPrice += pricesInceases % 100;
            bulletStats.bulletSpeed += bulletSpeedIncrease;
            bulletSpeedLevel++;
            UpdateUI();
            if (maxUpgradeLevels == true && bulletSpeedLevel >= maxBulletSpeedLevel)
            {
                disableBS.GetComponent<Button>().interactable = false;
            }
        }
        
    }

    public void UpgradeHealth()
    {
        if (playerHPThings.playerMoney >= maxHealthPrice)
        {
            playerHPThings.playerMoney -= maxHealthPrice;
            maxHealthPrice += pricesInceases % 100;
            playerHPThings.maxHealth += maxHealthIncrease;
            playerHPThings.health++;
            maxHealthLevel++;
            UpdateUI();
            if (maxUpgradeLevels == true && maxHealthLevel >= maxMaxHealthLevel)
            {
                disableMH.GetComponent<Button>().interactable = false;
            }
        }
    }


    void UpdateUI()
    {
        shootDelayText.text = (shootDelayLevel + " Fire Rate Up " + "Cost: " + shootDelayPrice);
        bulletSpeedText.text = (bulletSpeedLevel + " Bullet Speed Up " + "Cost: " + bulletSpeedPrice);
        maxHealthText.text = (maxHealthLevel + " Max Health Up " + "Cost: " + maxHealthPrice);
    }

    void Temporary()
    {

    }
}
