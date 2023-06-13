using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacing : MonoBehaviour
{
    public Transform placingPos;
    public Transform placingTower;
    Transform player;
    //public bool hasTower;
    public bool placedTower = false;
    public float placingRange = 1;

    public int towerPrice;
    PlayerHP playerStats;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStats = player.GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 towerDistance = new Vector2(placingPos.position.x - player.position.x, placingPos.position.y - player.position.y);
        if (towerDistance.magnitude < placingRange && placedTower == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        //Debug.Log("Player Distance: " + towerDistance);


    }

    public void PlaceTower()
    {
        if (placedTower == false && playerStats.playerMoney >= towerPrice)
        {
            Instantiate(placingTower, placingPos.position, Quaternion.identity);
            playerStats.playerMoney -= towerPrice;
            gameObject.SetActive(false);
        }
    }
}
