using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophySpawner : MonoBehaviour
{
    public int ran;
    public GameObject trophy;
    public GameObject projectile;
    public Vector3 a;
    public Vector3 b;
    public Vector3 c;
    public Vector3 d;
    public GameObject[] trophies;
    //Bools to prevent less trophy spawning in the same area -- (less because the range they can spawn can still reach into other spawnns on hopefully rare occasions)
    bool spawnA = false;
    bool spawnB = false;
    bool spawnC = false;
    bool spawnD = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        trophies = GameObject.FindGameObjectsWithTag("Trophy");
        if(trophies.Length <= 0)
        {
            //Determines which of the 4 spots to spawn at
            ran = Random.Range(1, 4);
            Debug.Log(ran);
            //Spawning if statements
            if (ran == 1 && spawnA != true)
            {
                trophy = Instantiate(projectile, a * Random.Range(-2f, 2f), Quaternion.identity) as GameObject;
                DisableAllBools();
                spawnA = true;
                //Function placed before assigning spawnA to "true" so it doesn't automatically re-disable it
            }
            if (ran == 2 && spawnB != true)
            {
                trophy = Instantiate(projectile, b * Random.Range(-2f, 2f), Quaternion.identity) as GameObject;
                DisableAllBools();
                spawnB = true;
            }
            if (ran == 3 && spawnC != true)
            {
                trophy = Instantiate(projectile, c * Random.Range(-2f, 2f), Quaternion.identity) as GameObject;
                DisableAllBools();
                spawnC = true;
            }
            if (ran == 4 && spawnD != true)
            {
                trophy = Instantiate(projectile, d * Random.Range(-2f, 2f), Quaternion.identity) as GameObject;
                DisableAllBools();
                spawnD = true;
            }
        }
       
    }

    void DisableAllBools()
    {
        //Disables the rest of the bools
        spawnA = false;
        spawnB = false;
        spawnC = false;
        spawnD = false;
    }

}
