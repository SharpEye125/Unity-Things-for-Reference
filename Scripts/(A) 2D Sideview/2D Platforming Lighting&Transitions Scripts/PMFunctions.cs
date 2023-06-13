using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SimpleFunction();
        int damage = DamageCalc(42, 12);
        
    }
    
    void SimpleFunction()
    {
        Debug.Log("Hello there good sir!");
    }

    public int DamageCalc(int damage, int armor)
    {
        Debug.Log("You deal" + (damage - armor) + "damage");
        return damage - armor;
    }

    public int DamageCalc(int damage, int armor, bool crit)
    {
        Debug.Log("You deal" + (damage - armor) + "damage");
        return damage - armor;
    }

}
