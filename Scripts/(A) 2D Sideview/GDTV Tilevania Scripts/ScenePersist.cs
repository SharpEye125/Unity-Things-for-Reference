using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{





    void Awake()
    {

        int numOfGamePersists = FindObjectsOfType<ScenePersist>().Length;
        if (numOfGamePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetGamePersist()
    {
        Destroy(gameObject);
    }
}
