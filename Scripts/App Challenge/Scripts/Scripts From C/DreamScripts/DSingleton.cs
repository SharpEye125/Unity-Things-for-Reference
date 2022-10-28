using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSingleton : MonoBehaviour
{
    public static int cubeacount = 0;
    public void Awake()
    {
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void add()
    {
        cubeacount = cubeacount + 1;
    }
    public void take()
    {
        cubeacount = cubeacount - 1;
    }
}
