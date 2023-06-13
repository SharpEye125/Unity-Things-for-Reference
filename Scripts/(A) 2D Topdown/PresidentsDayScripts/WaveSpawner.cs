using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
        [Header("Wave Specific SPs")]
        public Transform[] spawnPoints;

    }
    public Wave[] waves;
    public int nextWave = 0;

    //Used for random spawnpoints:
    public Transform[] spawnPoint;

    PlayerHP playerHealth;
    Transform player;

    public Transform defaultEnemy;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    public float searchCountdown = 1f;

    public float endWaveWait = 5f;
    [Header("Count Down UI")]
    public Text countdownText;
    public Text currentWaveText;
    public Text waveNameText;
    public string winText = "You Win!";

    public SpawnState state = SpawnState.COUNTING;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHP>();
        //waveCountdown = timeBetweenWaves;
        waveCountdown = 5;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
                
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        playerHealth.health = playerHealth.maxHealth;
        
        if(nextWave + 1 > waves.Length - 1)
        {
            //nextWave = 0;
            Debug.Log("All waves complete!");
            waveCountdown = 10000;
            StartCoroutine("EndWait");
        }
        else
        {
            nextWave++;

        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        if (waveNameText != null)
        {
            waveNameText.text = (_wave.name);
        }
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        for (int i = 0; i < _wave.count; i++)
        {
            //Debug.Log("Spawning Enemy:" + i + " Out of " + _wave.count);
            SpawnEnemy(_wave, _wave.enemy, spawnPoint);
            yield return new WaitForSeconds(1f/_wave.rate);
        }
        state = SpawnState.WAITING;

        yield break;
    }

    IEnumerator EndWait()
    {
        countdownText.text = (winText);
        yield return new WaitForSeconds(endWaveWait);
        SceneManager.LoadScene("EndScene");
        yield break;
    }

    void SpawnEnemy(Wave _wave, Transform[] _enemy, Transform[] spawnPoint)
    {
        //Don't mind this: Transform _enemy, Transform _spawnPoint

        //Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
        //for random spawnpoints:

        
        if (_wave.enemy.Length == 0)
        {
            Transform _sp = spawnPoint[Random.Range(0, spawnPoint.Length)];
            Instantiate(defaultEnemy, _sp.position, _sp.rotation);
            return;
        }
        if (_wave.spawnPoints.Length > 0)
        {
            if(_wave.spawnPoints != null)
            {
                Transform _enemies = _enemy[Random.Range(0, _wave.enemy.Length)];
                Transform _sps = _wave.spawnPoints[Random.Range(0, _wave.spawnPoints.Length)];
                Instantiate(_enemies, _sps.position, _sps.rotation);
                //Debug.Log("Spawning Enemy: " + _wave.enemy.name + " At SP" + _sps.name);
                
            }
            else
            {
                Transform _enemies = _enemy[Random.Range(0, _wave.enemy.Length)];
                //for random general spawnpoints:
                Transform _sp = spawnPoint[Random.Range(0, spawnPoint.Length)];
                Instantiate(_enemies, _sp.position, _sp.rotation);
            }
        }
        else
        {
            Transform _enemies = _enemy[Random.Range(0, _wave.enemy.Length)];
            //for random general spawnpoints:
            Transform _sp = spawnPoint[Random.Range(0, spawnPoint.Length)];
            Instantiate(_enemies, _sp.position, _sp.rotation);
        }
    }
    void UpdateUI()
    {
        currentWaveText.text = ("Wave: " + (nextWave + 1));
        if (state == SpawnState.COUNTING)
        {
            countdownText.enabled = true;
            countdownText.text = string.Format("Next Wave: {0:#0.0}", waveCountdown);
            //countdownText.text = ("Time till Next Wave: " + waveCountdown);
        }
        else
        {
            countdownText.enabled = false;
        }
    }
}
