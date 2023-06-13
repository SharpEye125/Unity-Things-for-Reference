using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ArcadeScoring : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int scoreTotal = 0;
    public int scorePerTrophy;
    public AudioClip trophyCollect;
    public AudioClip playerHit;

    public Color playerColor;
    public Color playerHitColor;
    Color currentColor;
    SpriteRenderer myRenderer;
    bool gotHit = false;
    float timer;
    public float colorFadeRate = 0.2f;
    public float colorChangeDuration = 0.3f;

    void Start()
    {
        scoreText.text = "Score: " + scoreTotal;
        myRenderer = GetComponent<SpriteRenderer>();
        currentColor = playerColor;
        myRenderer.color = playerColor;
    }
    //Enemy Contact
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Enemy Bullets
        if (collision.tag == "Bullet")
        {

            scoreTotal -= scorePerTrophy;
            scoreText.text = "Score: " + scoreTotal;

            currentColor = playerHitColor;
            gotHit = true;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(playerHit);

            if (scoreTotal < 1)
            {
                scoreTotal = 0;
                scoreText.text = "Score: " + scoreTotal;

                
            }
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Trophy")
        {
            Singleton.stress -= 1;
            Singleton.ribsgot += 1;
            scoreTotal += scorePerTrophy;
            scoreText.text = "Score: " + scoreTotal;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(trophyCollect);
            Destroy(collision.gameObject);
        }
    }
    private void Update()
    {
        
        if (gotHit == true)
        {
            timer += Time.deltaTime;
            if (timer >= colorChangeDuration)
            {
                Singleton.energy -= 1;
                currentColor = playerColor;
                gotHit = false;
                timer = 0f;
            }
        }
        myRenderer.color = Color.Lerp(myRenderer.color, currentColor, colorFadeRate);

    }
}
