using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCollect : MonoBehaviour
{
    public int CoinCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            CoinCount++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "BitCoin")
        {
            CoinCount--;
            Destroy(collision.gameObject);
        }
        if (CoinCount == 20)
        {
            SceneManager.LoadScene("YouWin");
        }
    }
}
