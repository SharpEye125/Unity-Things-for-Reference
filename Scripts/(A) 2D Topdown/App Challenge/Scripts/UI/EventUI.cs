using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Canvas eventCanvas;
    string eventString;
    float defaultSize;
    public Canvas buttonCanvas;
    public Button eventButton1;
    public Button eventButton2;
    public static string eventButtonText1;
    public static string eventButtonText2;
    public static int eventNum;
    public Image activityBlocker;
    public Text activityBlockText;
    //Blockers for when energy < 10 or so
    public Image tiredBlocker;
    public Image tiredBlocker2;

    public Canvas rentCanvas;
    public TextMeshProUGUI rentText;

    public TextMeshProUGUI dailyNecessitiesText;
    // Start is called before the first frame update
    void Start()
    {
        defaultSize = text.fontSize;
        eventCanvas.enabled = true;
        buttonCanvas.enabled = false;
        UnblockActivityButtons();
        UnBlockFunAndWork();
        RentPopOpen();
        rentCanvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = SceneLoader.eventText;
        dailyNecessitiesText.text = SceneLoader.dnText;
        eventString = SceneLoader.eventText;
        if (SceneLoader.randomEventBool == true)
        {
            FindObjectOfType<SceneLoader>().RandomEvent();
        }
        if (eventString.Length > 140)
        {
            text.fontSize = 20f;
        }
        else if (eventString.Length > 72)
        {
            text.fontSize = 24f;

        }
        else
        {
            text.fontSize = defaultSize;
        }
        if (Singleton.energy < 10)
        {
            BlockFunAndWork();
        }
        else
        {
            UnBlockFunAndWork();
        }
    }
    public void EventPopUp()
    {
        if (eventCanvas.enabled == false)
        {
            eventCanvas.enabled = true;
        }
        else
        {
            eventCanvas.enabled = false;
        }

    }
    public void CloseEventPopUp()
    {
        //To be put on a button
        eventCanvas.enabled = false;
        buttonCanvas.enabled = false;

    }
    public void EnableEventButtons()
    {
        buttonCanvas.enabled = true;
        eventButton1.GetComponentInChildren<TextMeshProUGUI>().text = eventButtonText1;
        eventButton2.GetComponentInChildren<TextMeshProUGUI>().text = eventButtonText2;
    }
    public void Button1Function()
    {
        switch (eventNum)
        {
            case 1:
                BuyFood();
                DisableEventButtons();
                UnblockActivityButtons();
                break;
            case 2:
                GoToMovies();
                DisableEventButtons();
                UnblockActivityButtons();
                break;
            case 3:
                GoToWork();
                DisableEventButtons();
                UnblockActivityButtons();
                break;
            case 4:
                WalkToWork();
                DisableEventButtons();
                UnblockActivityButtons();
                break;
            case 5:
                WatchParentsHouse();
                DisableEventButtons();
                UnblockActivityButtons();
                break;
            case 6:
                PurchaseCookies();
                DisableEventButtons();
                break; 
        }
    }
    public void Button2Function()
    {
        switch (eventNum)
        {
            case 1:
                StayHungry();
                DisableEventButtons();
                UnblockActivityButtons();
                break;
            case 2:
                DeclineFriends();
                DisableEventButtons();
                UnblockActivityButtons();
                break;
            case 3:
                DontWork();
                DisableEventButtons();
                UnblockActivityButtons();
                break;
            case 4:
                TakeBus();
                DisableEventButtons();
                UnblockActivityButtons();
                break;
            case 5:
                DeclineParents();
                DisableEventButtons();
                UnblockActivityButtons();
                break;
            case 6:
                Decline();
                DisableEventButtons();
                break;
        }
    }
    public void DisableEventButtons()
    {
        buttonCanvas.enabled = false;
    }
    //Event Functions
    public void TakeBus()
    {
        Singleton.busToWork = true;
        Singleton.walkToWork = false;
        SceneLoader.eventText = "The next time you go to work:\n-3 Money";
    }
    public void WalkToWork()
    {
        Singleton.walkToWork = true;
        Singleton.busToWork = false;
        SceneLoader.eventText = "The next time you go to work:\n-4 Energy";
    }
    public void PurchaseCookies()
    {
        Singleton.money -= 3;
        Singleton.energy += 2;
        SceneLoader.eventText = "The cookies were delicious\n+2 Energy";
        DisableEventButtons();
    }
    public void Decline()
    {
        DisableEventButtons();
        SceneLoader.eventText = "The girl scouts moved on to someone else";
    }
    //Rent Due Canvas Functions
    public void RentPopUp()
    {
        if (rentCanvas.enabled == false)
        {
            rentCanvas.enabled = true;
            if (SceneLoader.day == SceneLoader.taxDays - 5 || SceneLoader.day + 5 == SceneLoader.taxDays)
            {
                rentText.text = " Rent is due\n-" + SceneLoader.taxAmount + " Money";
            }
            else if (SceneLoader.taxDays - SceneLoader.day > 1)
            {
                rentText.text = SceneLoader.taxDays - SceneLoader.day + "\ndays left until rent is due";
            }
            else if(SceneLoader.taxDays - SceneLoader.day == 1)
            {
                rentText.text = SceneLoader.taxDays - SceneLoader.day + "\nday left until rent is due";
            }
        }
        else if (rentCanvas.enabled == true)
        {
            rentCanvas.enabled = false;
        }
    }
    public void RentPopOpen()
    {
        rentCanvas.enabled = true;
        if (SceneLoader.day == SceneLoader.taxDays - 5 || SceneLoader.day + 5 == SceneLoader.taxDays)
        {
            rentText.text = " Rent is due\n-" + SceneLoader.taxAmount + " Money";
        }
        else if (SceneLoader.taxDays - SceneLoader.day > 1)
        {
            rentText.text = SceneLoader.taxDays - SceneLoader.day + "\ndays left until rent is due";
        }
        else if (SceneLoader.taxDays - SceneLoader.day == 1)
        {
            rentText.text = SceneLoader.taxDays - SceneLoader.day + "\nday left until rent is due";
        }
    }
    public void BlockActivityButtons()
    {
        activityBlocker.enabled = true;
        activityBlockText.enabled = true;
    }
    public void UnblockActivityButtons()
    {
        activityBlocker.enabled = false;
        activityBlockText.enabled = false;
    }
    public void GoToMovies()
    {
        SceneLoader.eventText = "You had a blast hanging out.\n-10 Money\n-5 Stress";
        DisableEventButtons();
    }
    public void DeclineFriends()
    {
        SceneLoader.eventText = "You declined their offer, but worry about what they think of you.\n+3 Stress";
        Singleton.stress += 3;
        DisableEventButtons();
    }
    public void BlockFunAndWork()
    {
        tiredBlocker.enabled = true;
        tiredBlocker2.enabled = true;
        tiredBlocker.GetComponentInChildren<Text>().enabled = true;
        tiredBlocker2.GetComponentInChildren<Text>().enabled = true;
        //tiredBlockText.enabled = true;
    }
    public void UnBlockFunAndWork()
    {
        tiredBlocker.enabled = false;
        tiredBlocker2.enabled = false;
        tiredBlocker.GetComponentInChildren<Text>().enabled = false;
        tiredBlocker2.GetComponentInChildren<Text>().enabled = false;
        //tiredBlockText.enabled = false;
    }
    public void EventChanceTester()
    {
        SceneLoader.eventChance -= 1;
        if (SceneLoader.eventChance < 1)
        {
            SceneLoader.eventChance = 5;
        }
        Debug.Log("Changed chance to: " + SceneLoader.eventChance);
    }
    public void GoToWork()
    {
        SceneLoader.eventText = "You went to work and got a bonus for your work.\n+7 Money";
        Singleton.money += 10;
        DisableEventButtons();
        FindObjectOfType<SceneLoader>().Work();
    }
    public void DontWork()
    {
        SceneLoader.eventText = "You said you couldn't come in.\n-5 Money\n+3 Stress";
        Singleton.money -= 5;
        Singleton.stress += 3;
        DisableEventButtons();
    }
    public void WatchParentsHouse()
    {
        SceneLoader.eventText = "You accepted and they compensated you with some homemade brownies.\n-10 Stress";
        Singleton.stress -= 10;
        DisableEventButtons();
    }
    public void DeclineParents()
    {
        SceneLoader.eventText = "You said you're busy that day and wished them safe travels.";
        DisableEventButtons();
    }
    public void BuyFood()
    {
        Singleton.money -= 10;
        Singleton.energy -= 3;
        SceneLoader.eventText = "You went out and got stocked up on food for awhile.\n-10 Money\n-3 Energy";
        DisableEventButtons();
    }
    public void StayHungry()
    {
        Singleton.energy -= 10;
        SceneLoader.eventText = "You stayed home and got tired from hunger\n-10 Energy";
    }
}
