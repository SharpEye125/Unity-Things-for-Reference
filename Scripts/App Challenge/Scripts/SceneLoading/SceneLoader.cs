using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public static bool startscores = true;
    public static int day;
    //Event variables
    public static int taxAmount = 20;
    public static string eventText = "Event #";
    //dur == days until rent
    //static int dur;
    public static int taxDays = 5;
    public static int eventChance = 0;
    static int ran;
    public static int dn;
    public static string dnText;
        //dn = daily necessities
    static int events = 0;
    //Bools so some stat-based text doesn't re-apply itself
    bool lowFunds = false;
    bool highStress = false;
    public static bool lowEnergy = false;
    public static bool randomEventBool;

    public void LoadMenu()
    {
        Singleton.ResetAllVariables();
        SceneManager.LoadScene("MenuScene");
        Singleton.money = 30;
        Singleton.energy = 40;
        Singleton.stress = 25;
        startscores = true;
        day = 0;
    }

    public void Room()
    {
        if (Singleton.btd == false)
        {
            SceneManager.LoadScene("Bedroom Info");
            Singleton.btd = true;
            Debug.Log("Yes");
        }
        else if (Singleton.btd == true)
        {
            SceneManager.LoadScene("Bedroom Scene");
            Debug.Log("Yes this");
            if (startscores == true)
            {
                Singleton.money = 30;
                Singleton.energy = 40;
                Singleton.stress = 25;
                eventChance = 4;
                day = 1;
                startscores = false;
                AmbientEvents();
                DailyNecessities();
            }
            else
            {
                day += 1;
                AmbientEvents();
                DailyNecessities();
                if (day % 5 == 0)
                {
                    //Debug.Log("Tax Day!");
                    TaxEvent();
                }
                else if (Singleton.streak >= 3 || Singleton.nws >= 3)
                {
                    CheckSceneStreak();
                }
                else if (eventChance > 0)
                {
                    ran = Random.Range(1, eventChance);
                    if (ran == 1)
                    {
                        randomEventBool = true;
                        RandomEvent();
                    }
                }
                else
                {
                    AmbientEvents();

                }
                StatLevelChecker();
                EventChanceChanger();
            }


        }
    }
    public void retry()
    {
        Singleton.ResetAllVariables();
        Singleton.money = 30;
        Singleton.energy = 40;
        Singleton.stress = 25;
        startscores = true;
        day = 0;
        taxDays = 5;
        lowEnergy = false;
        lowFunds = false;
        highStress = false;
        randomEventBool = false;
        eventChance = 4;
        Room();
    }

    public void Work()
    {
        if (Singleton.wtd == false)
        {
            SceneManager.LoadScene("Work Info");
            Singleton.wtd = true;
            Debug.Log("Yes");
        }
        else if (Singleton.wtd == true)
        {
            SceneManager.LoadScene("Work Scene");
            Singleton.wwent += 1;
            Debug.Log("Yes this");

            if (Singleton.isSick == true)
            {
                Singleton.energy -= 4;
                Singleton.sickDays--;
                if (Singleton.sickDays <= 0)
                {
                    Singleton.isSick = false;
                }
            }
            if (Singleton.walkToWork == true)
            {
                Singleton.energy -= 4;
                Singleton.walkToWork = false;
                Singleton.busToWork = false;
            }
            else if (Singleton.busToWork == true)
            {
                Singleton.money -= 3;
                Singleton.busToWork = false;
                Singleton.walkToWork = false;
            }
            if (Singleton.streak >= 1 && Singleton.wss == true)
            {
                Singleton.streak += 1;
            }
            else
            {
                Singleton.streak = 1;
                Singleton.nws = 0;
                DisableSceneStreaks();
                Singleton.wss = true;
            }
        }
    }

    public void Dream()
    {
        SceneManager.LoadScene("Dream Scene");
    }

    public void Fun()
    {
        if (Singleton.ftd == false)
        {
            SceneManager.LoadScene("Fun Info");
            Singleton.ftd = true;
            Debug.Log("Yes");
        }
        else if (Singleton.ftd == true)
        {
            SceneManager.LoadScene("Fun Scene");
            Singleton.fwent += 1;
            Debug.Log("Yes this");
            if (Singleton.streak >= 1 && Singleton.fss == true)
            {
                Singleton.streak += 1;
                Singleton.nws += 1;
            }
            else
            {
                Singleton.streak = 1;
                Singleton.nws += 1;
                DisableSceneStreaks();
                Singleton.fss = true;
            }
        }
    }

    public void Rest()
    {
        if (Singleton.rtd == false)
        {
            SceneManager.LoadScene("Rest Info");
            Singleton.rtd = true;
            Debug.Log("Yes");
        }
        else if (Singleton.rtd == true)
        {
            SceneManager.LoadScene("Rest Scene");
            Singleton.rwent += 1;
            Debug.Log("Yes this");
            if (Singleton.streak >= 1 && Singleton.rss == true)
            {
                Singleton.streak += 1;
                Singleton.nws += 1;
            }
            else
            {
                Singleton.streak = 1;
                Singleton.nws += 1;
                DisableSceneStreaks();
                Singleton.rss = true;
            }
        }
    }

    public void BedroomInfo()
    {
        SceneManager.LoadScene("Bedroom Info");
    }

    public void WorkInfo()
    {
        SceneManager.LoadScene("Work Info");
    }

    public void RestInfo()
    {
        SceneManager.LoadScene("Rest info");
    }

    public void LoseScene()
    {
        SceneManager.LoadScene("Lose Scene");

    }

    public void FunInfo()
    {
        SceneManager.LoadScene("Fun Info");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void TaxEvent()
    {
        Singleton.money -= taxAmount;
        taxDays = day + 5;
        FindObjectOfType<EventUI>().RentPopUp();
        //EventPopUp();
        //Example:
        FindObjectOfType<EventUI>().rentCanvas.enabled = true;
        if (Singleton.money < 0)
        {
            Singleton.moneyloss = true;
        }
    }
    public void EventChanceChanger()
    {
        switch (day)
        {
            case 5:
                eventChance = 2;
                Debug.Log(eventChance + " Event chance");
                break;
            case 10:
                eventChance = 3;
                Debug.Log(eventChance + " Event chance");
                break;
            case 15:
                eventChance = 2;
                Debug.Log(eventChance + " Event chance");
                break;
            case 20:
                eventChance = 3;
                Debug.Log(eventChance + " Event chance");
                break;
            case 25:
                eventChance = 2;
                Debug.Log(eventChance + " Event chance");
                break;
            case 30:
                eventChance = 1;
                Debug.Log(eventChance + " Event change");
                break;
            default:
                if (day > 30)
                {
                    eventChance = 1;
                }
                break;
        }
    }
    public void RandomEvent()
    {
        if (randomEventBool == true && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Bedroom Scene"))
        {
            randomEventBool = false;
            FindObjectOfType<EventUI>().DisableEventButtons();
            events = Random.Range(1, 7);
            Debug.Log("Event: " + events);
            switch (events)
            {
                case 1:
                    events = Random.Range(2, 6);



                    //A switch is used in a switch to 'simplify' making events tougher as the player gets thru the month. Each event getting more harsh after each time the chance of them occuring goes up
                    switch (events)
                    {
                        case 5:
                            eventText = "The birdsong outside gave you a moment of relaxation.\n-2 Stress";
                            Singleton.stress -= 2;

                            break;
                        case 4:
                            if (Singleton.rss == true)
                            {
                                eventText = "The neighbors had a loud party last night.\n-3 Energy";
                                Singleton.energy -= 3;
                            }
                            else
                            {
                                eventText = "You hit a pothole on your way home popping a tire.\n-10 Money";
                                Singleton.money -= 10;
                            }
                            break;
                        case 3:
                            eventText = "A water pipe broke causing water damage\n-15 Money";
                            Singleton.money -= 15;
                            break;
                        case 2:
                            //You run out of food, go out and buy more, or don't and lose energy
                            eventText = "You just ran out of food, go out and buy more, or don't and hunger.";
                            EventUI.eventButtonText1 = "Buy Food";
                            EventUI.eventButtonText2 = "Hunger";
                            EventUI.eventNum = 1;
                            FindObjectOfType<EventUI>().BlockActivityButtons();
                            FindObjectOfType<EventUI>().EnableEventButtons();

                            break;
                        default:
                            //eventText = "You're using the test button right now";
                            RandomEvent();
                            break;
                    }
                    break;

                case 2:
                    events = Random.Range(2, 6);
                    switch (events)
                    {
                        case 5:
                            eventText = "You went out and got a coffee\n-2 Money\n+1 Energy";
                            Singleton.money -= 2;
                            Singleton.energy += 1;

                            break;
                        case 4:
                            eventText = "Your friends invited you out to see a new movie.\nIt will cost 10 money but you'll have fun.";
                            EventUI.eventButtonText1 = "Accept";
                            EventUI.eventButtonText2 = "Decline";
                            EventUI.eventNum = 2;
                            FindObjectOfType<EventUI>().BlockActivityButtons();
                            FindObjectOfType<EventUI>().EnableEventButtons();
                            //multiple choice of going for not. Going costs 10 money but lose 5 stress. Declining raises stress by 5 for overthinking your friends view of you for not going
                            break;
                        case 3:
                            if (Singleton.rss != true)
                            {
                                Singleton.stress += 4;
                                eventText = "The power was out when you got home\n+4 Stress";
                            }
                            else
                            {
                                Singleton.stress += 5;
                                eventText = "There's a power outtage in your area from an overnight thunderstorm\n+5 Stress";
                            }
                            break;
                        case 2:
                            Singleton.money -= 5;
                            eventText = "It's one of your friend's birthday so you bought them a gift.\n -5 Money";
                            break;
                        default:
                            RandomEvent();
                            break;
                    }
                    break;

                case 3:
                    events = Random.Range(2, 6);
                    switch (events)
                    {
                        case 5:
                            if (Singleton.wss == true || Singleton.fss == true)
                            {
                                eventText = "It rained on your way home making you drive extra safe\n+3 Stress";
                                Singleton.stress += 3;
                            }
                            else
                            {
                                eventText = "You woke up to the calming sound of rain\n-2 Stress";
                                Singleton.stress -= 2;
                            }

                            break;
                        case 4:
                            eventText = "You're called in for work by your boss\nGo to work and get a bonus.\nDon't go and get a deduction.";
                            EventUI.eventButtonText1 = "Go";
                            EventUI.eventButtonText2 = "Don't go";
                            EventUI.eventNum = 3;
                            FindObjectOfType<EventUI>().BlockActivityButtons();
                            FindObjectOfType<EventUI>().EnableEventButtons();
                            break;
                        case 3:
                            eventText = "You saw an old friend and got to catch-up and chat.\n-2 Energy\n-2 Stress";
                            Singleton.energy -= 2;
                            Singleton.stress -= 2;
                            break;
                        case 2:
                            Singleton.stress += 5;
                            eventText = "You haven't heard from your friends in while.\n+5 Stress";
                            Singleton.stress += 5;
                            break;
                        default:
                            RandomEvent();
                            break;
                    }

                    break;

                case 4:
                    events = Random.Range(2, 6);
                    switch (events)
                    {
                        case 5:
                            eventText = "Your car breaks down -10 Money.\nWhile it's being repaired:\nWalk to work: -4 Energy\nTake the bus: -3 Money";
                            Singleton.money -= 10;
                            EventUI.eventButtonText1 = "Walk";
                            EventUI.eventButtonText2 = "Take Bus";
                            EventUI.eventNum = 4;
                            FindObjectOfType<EventUI>().BlockActivityButtons();
                            FindObjectOfType<EventUI>().EnableEventButtons();

                            break;
                        case 4:
                            if (Singleton.wss == true)
                            {
                                eventText = "The coffee maker at work broke while you were using it.\n+4 Stress";
                                Singleton.stress += 4;
                            }
                            else
                            {
                                eventText = "Your ran out of coffee mix, so you went out and got more.\n-4 Money\n+2 Stress";
                                Singleton.money -= 4;
                                Singleton.stress += 2;
                            }
                            break;
                        case 3:
                            eventText = "There's a strong wind warning in the weather forecast.\n+3 Stress";
                            Singleton.stress += 3;

                            break;
                        case 2:
                            eventText = "The bird nest outside has new adorable baby birds\n-2 Stress";
                            Singleton.stress -= 2;
                            break;
                        default:
                            RandomEvent();
                            break;
                    }

                    break;

                case 5:
                    events = Random.Range(2, 6);
                    switch (events)
                    {
                        case 5:
                            if (Singleton.isSick != true)
                            {
                                eventText = "You got sick and will be for the next 2 days.\nIf you go to work you will lose energy faster";
                                Singleton.isSick = true;
                                Singleton.sickDays = 2;
                            }
                            else
                            {
                                eventText = "Your coworkers sent you a get well soon basket\n+1 Energy\n-1 Stress";
                                Singleton.stress -= 1;
                                Singleton.energy += 1;
                            }

                            break;
                        case 4:
                            eventText = "Your parents called and asked if you could watch the house while they're out of town";
                            EventUI.eventButtonText1 = "Accept";
                            EventUI.eventButtonText2 = "Decline";
                            EventUI.eventNum = 5;
                            FindObjectOfType<EventUI>().EnableEventButtons();
                            break;
                        case 3:
                            eventText = "You dreamt you were being controlled and inside of a game.\n+20 Stress";
                            Singleton.stress += 20;
                            break;
                        case 2:
                            eventText = "You awoke to a loud noise in the night losing you sleep.\n-3 Energy\n+2 Stress";
                            Singleton.energy -= 3;
                            Singleton.stress += 2;
                            break;
                        default:
                            RandomEvent();
                            break;
                    }
                    //set up thing for work loader to check if sick
                    break;

                case 6:
                    events = Random.Range(2, 6);
                    switch (events)
                    {
                        case 5:
                            eventText = "Girl scouts knocked and are offering you cookies for 3 money";
                            EventUI.eventButtonText1 = "Buy";
                            EventUI.eventButtonText2 = "Decline";
                            EventUI.eventNum = 6;
                            FindObjectOfType<EventUI>().EnableEventButtons();

                            break;
                        case 4:
                            eventText = "You dreamt you were being hunted down by robots.\n+5 Stress";
                            Singleton.stress += 5;
                            break;
                        case 3:
                            eventText = "A friend sent you money out of the blue.\n+5 Money\n -4 Stress";
                            Singleton.money += 5;
                            Singleton.stress -= 4;

                            break;
                        case 2:
                            eventText = "You dreamt you inherited your grandpas farm in a valley town.\n-5 Stress";
                            Singleton.stress -= 5;
                            break;
                        default:
                            RandomEvent();
                            break;
                    }

                    break;
            }
            EnableEventUI();
        }
    }
    public void AmbientEvents()
    {
        EnableEventUI();
        events = Random.Range(1, 8);
        //Note: idk really what to put for these other than weather
        //Side note: ambient events with weather that's different from the window might cause a bit of immersion breaking
        switch (events)
        {
            case 1:
                eventText = "It's a bright and sunny day.";
                break;
            case 2:
                eventText = "Suns shining with the occasional rolling cloud coverage.";
                break;
            case 3:
                eventText = "It's cloudy outside.";
                break;
            case 4:
                eventText = "There's wind rustling the trees.";
                break;
            case 5:
                eventText = "The weather is looking gloomy out there";
                break;
            case 6:
                eventText = "Suitable weather for a walk";
                break;
            default:
                //make this an easter egg
                ran = Random.Range(1, 21);
                if (ran == 20)
                {
                    eventText = "It's a beautiful day outside, birds are singing, flowers a blooming. On days like this, people like you...\n\nShould have a wonderful day!";
                }
                else if (ran == 1)
                {
                    eventText = "It's a beautiful day outside, birds are singing, flowers a blooming. On days like this, people like you...\n\nShould be burning a candle wick";
                }
                else
                {
                    eventText = "You're missing moms cooking.";
                    //Butterscotch-Cinnamon Pie.
                }
                break;
        }
    }
    public void RandomEventTest()
    {
        //eventChance = 5;
        randomEventBool = true;
        RandomEvent();


    }
    public void EnableEventUI()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Bedroom Scene"))
        {
            FindObjectOfType<EventUI>().eventCanvas.enabled = true;
        }
        else
        {
            Debug.Log("Not in bedroom Scene");
        }
    }
    public void DisableSceneStreaks()
    {
        Singleton.wss = false;
        Singleton.rss = false;
        Singleton.fss = false;
    }
    public void CheckSceneStreak()
    {
        if (Singleton.nws >= 3)
        {
            eventText = "You're starting to get stressed over the work you haven't completed.\n+10 Stress ";
            Singleton.stress += 10;
        }
        else if (Singleton.streak >= 2)
        {
            if (Singleton.wss == true)
            {
                eventText = "You're getting increasingly tired from the long hours you've worked.\n-5 Energy";
                Singleton.energy -= 5;
            }
            else if (Singleton.fss == true)
            {
                eventText = "Your Forg high score grind has left you worrying that someone will take it from you.\n+5 Stress";
                Singleton.stress += 5;
            }
            else if (Singleton.rss == true)
            {
                eventText = "You're feeling lathargic from all you're sleeping and subsequently lost out on some energy\n-5 Energy";
                Singleton.energy -= 5;
            }
        }
    }
    public void StatLevelChecker()
    {
        if (Singleton.stress >= 50)
        {
            Singleton.energy -= 5;
            if (highStress == false)
            {
                eventText = eventText + "\nYour high stress is making you more tired\n -5 Energy";
                highStress = true;
            }

        }
        else
        {
            highStress = false;
        }
        if (Singleton.money < 10)
        {
            Singleton.stress += 10;
            if (lowFunds == false)
            {
                eventText = eventText + "\nYour low funds makes you panic\n+10 Stress";
                lowFunds = true;
            }

        }
        else
        {
            lowFunds = false;
        }
        if (Singleton.energy < 10)
        {
            //Enable a blocker to work and fun buttons
            
            Singleton.stress += 5;
            if (lowEnergy == false)
            {
                eventText = eventText + "\n\nYou are too exhausted to work or have fun.\n+5 Stress";
                lowEnergy = true;
            }
        }
        else
        {
            lowEnergy = false;
            
        }
    }
    public void DailyNecessities()
    {
        
        if (day == 1)
        {
            dnText = "No daily necessities today.";
        }
        else
        {
            dn = Random.Range(1, 4);
            Singleton.money -= dn;
            dnText = "Daily necessities costed\n" + dn + " Money";
        }
        
    }
}
