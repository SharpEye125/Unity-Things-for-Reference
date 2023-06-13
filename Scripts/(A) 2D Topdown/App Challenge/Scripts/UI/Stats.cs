using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    public Text textm;
    public Text texts;
    public Text texte;
    public int moneyAmount = 0;
    public int stressAmount = 0;
    public int energyAmount = 0;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        stressAmount =Singleton.stress;
        moneyAmount = Singleton.money;
        energyAmount = Singleton.energy;
        Debug.Log("Current Money Amount: " + moneyAmount);
        Debug.Log("Current Stress Amount: " + stressAmount);
        Debug.Log("Current Energy Amount: " + energyAmount);
        textm.text = (moneyAmount.ToString() + "$");
        texts.text = (stressAmount.ToString() + " Stress");
        texte.text = (energyAmount.ToString() + " Energy");
    }
}
