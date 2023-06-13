using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    public int lastLevel;
    // Update is called once per frame
    private void Start()
    {
        lastLevel = GameObject.Find("Player").GetComponent<Player>().level;
    }
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        {
            //FadeToNextLevel();

        }
    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        if (levelToLoad >= 4)
        {
            levelToLoad = 0;
        }
            SceneManager.LoadScene(levelToLoad);
    }
    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        return;
    }
    public void FadeToLastLevel(int buildIndex)
    {
        lastLevel = GameObject.Find("Player").GetComponent<Player>().level;
        if (lastLevel >= 3)
        {
            lastLevel = 2;
        }
        FadeToLevel(levelToLoad = lastLevel);
        switch (lastLevel)
        {
            case 0:
                FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            //case 1:
                //FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
                //break;
            //case 2:
                //FadeToLevel(SceneManager.GetActiveScene().buildIndex + 2);
                //break;
            case 3:
                FadeToLevel(SceneManager.GetActiveScene().buildIndex + 2);
                break;
        }
        return;
    }
}
