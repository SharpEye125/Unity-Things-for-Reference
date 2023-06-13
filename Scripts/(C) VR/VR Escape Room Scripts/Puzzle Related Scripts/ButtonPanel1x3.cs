using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPanel1x3 : MonoBehaviour
{

    //public int buttonNum = 1;
    public bool isPressed1;
    public bool isPressed2;
    public bool isPressed3;
    public Material correctMat;
    public Material incorrectMat;
    public Material defaultMat;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (TaskFulfilled() == true)
        //{
            //FindObjectOfType<PuzzleManager>().stage = 3;
        //}
    }


    public void Pressed1()
    {
        
        if(!isPressed2 && !isPressed3)
        {
            isPressed1 = true;
            button1.GetComponent<MeshRenderer>().material = correctMat;
            button2.GetComponent<MeshRenderer>().material = defaultMat;
            button3.GetComponent<MeshRenderer>().material = defaultMat;

        }
        else
        {
            IsPressedToFalse();
        }
        
    }
    public void Pressed2()
    {
        if (isPressed1 && !isPressed3)
        {
            isPressed2 = true;
            button2.GetComponent<MeshRenderer>().material = correctMat;
        }
        else
        {
            IsPressedToFalse();
        }
    }
    public void Pressed3()
    {
        if (isPressed1 && isPressed2)
        {
            isPressed3 = true;
            button3.GetComponent<MeshRenderer>().material = correctMat;
            FindObjectOfType<PuzzleManager>().stage = 3;
        }
        else
        {
            IsPressedToFalse();
        }
    }
    public bool TaskFulfilled()
    {
        if (isPressed1 == true && isPressed2 == true && isPressed3 == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void IsPressedToFalse()
    {
        isPressed1 = false;
        isPressed2 = false;
        isPressed3 = false;
        button1.GetComponent<MeshRenderer>().material = incorrectMat;
        button2.GetComponent<MeshRenderer>().material = incorrectMat;
        button3.GetComponent<MeshRenderer>().material = incorrectMat;

    }
    
}
