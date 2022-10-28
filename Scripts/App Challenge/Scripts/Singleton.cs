using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Singleton : MonoBehaviour
{
    public static int energy;
    public static int money;
    public static int stress;
   public static float score;
    public float daytime;
    public float timer;
    public static int streak;
    //wtd acronym == work tutorial done
    public static bool wtd;
    public static bool ftd;
    public static bool rtd;
    public static bool dtd;
    public static bool btd;
    //Scene streak bools   acronym wss == work scene streak
    public static bool wss;
    public static bool fss;
    public static bool rss;
    // nws acronym == Not Work Streak - used to check how long it's been since player last went to work
    public static int nws;
    public static bool isSick;
    public static int sickDays;
    public static bool walkToWork;
    public static bool busToWork;
    public string lastday;


    public static int wwent;
    public static int fwent;
    public static int rwent;
    public static int gemsgot;
    public static int ribsgot;
    public static bool stressloss;
    public static bool energyloss;
    public static bool moneyloss;

    public bool halff;
    public static bool half;
    


    public bool apple = true;
    // Start is called before the first frame update
    public static void ResetAllVariables()
    {
        money = 30;
        energy = 40;
        stress = 25;

        streak = 0;
        wtd = false;
        ftd = false;
        rtd = false;
        dtd = false;
        wss = false;
        fss = false;
        rss = false;
        nws = 0;
        isSick = false;
        sickDays = 0;
        walkToWork = false;
        busToWork = false;

        wwent = 0;
        rwent = 0;
        fwent = 0;
        gemsgot = 0;
        ribsgot = 0;
        stressloss = false;
        energyloss = false;
        moneyloss = false;
    }
    void Start()
    {
        score=100;
        daytime = 0;
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Work Scene")||
            SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Fun Scene") ||
            SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Rest Scene") )
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(lastday))
            {
                streak += 1;
            }
            else
            {
                if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Work Scene"))
                {
                    lastday = "Work Scene";
                }
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Fun Scene"))
                {
                    lastday = "Fun Scene";
                }
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Rest Scene"))
                {
                    lastday = "Rest Scene";
                }
                streak = 1;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        half = halff;
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.O) )
        {
            if (apple ==false)
            {
                SceneLoader.day += 1;
                Debug.Log("Cheater :( ");
                apple = true;
            }
        }
        else
        {
            apple = false;
        }
            Limit();
      //  Debug.Log("Daytime is " + daytime);
        if ( SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Work Scene") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Fun Scene") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Rest Scene") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dream Scene"))
        {
            timer += Time.deltaTime;
        }
        if (timer >= 1)
        {
            timer = 0;
            if(halff==true)
            {
                daytime += 2.5f;
            }
            else
            {
                daytime += 1;
            }
           
        }
        if (daytime >= 30 && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Dream Scene"))
        {
            FinishDay();
            daytime = 0;
            if (Singleton.dtd == false)
            {
                SceneManager.LoadScene("Dream Info");
                Singleton.dtd = true;
            }
            else if (Singleton.dtd == true)
            {
                SceneManager.LoadScene("Dream Scene");
            }

        }
        else if (daytime >= 30)
        {
            daytime = 0;
           
            FindObjectOfType<SceneLoader>().Room();
        
        }
    }


    public void Limit()
    {
        if(SceneLoader.startscores == true)
        {
            Singleton.money = 30;
            Singleton.energy = 40;
            Singleton.stress = 25;
            SceneLoader.startscores = false;
        }
        if (stress<0)
        {
            stress = 0;
        }
        if (stress >= 100)
        {
            stress = 100;
            if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Lose Scene"))
            {
                stressloss = true;
                SceneManager.LoadScene("Lose Scene");
            }
            
        }
        if (energy <= 0)
        {
            energy = 0;
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Lose Scene"))
            {
                energyloss = true;
                SceneManager.LoadScene("Lose Scene");
            }

        }
        if (moneyloss ==true)
        {
                SceneManager.LoadScene("Lose Scene");
        }

    }
    private void FinishDay()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Work Scene"))
        {
            if(halff == true)
            {
                energy -= 8;
            }
            else
            {
                energy -= 15;
            }
           
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Fun Scene"))
        {

            if (halff == true)
            {
                money -= 8;
            }
            else
            {
                money -= 15;
            }
           
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Rest Scene"))
        {
            if (halff == true)
            {
                stress += 8;
            }
            else
            {
               stress += 15;
            }
        }
    }

    public void Awake()
    {
        daytime = 0;
        int gameStatusCount = FindObjectsOfType<Singleton>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
    

