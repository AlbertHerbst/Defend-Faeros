using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float spawnRate;
    }

    public Transform enemySpawnPoint;

    public Wave[] waves;
    public int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    private float searchCountDown = 1f;

    public float difficultyMultiplier, wave;
    public Text waveText;

    private SpawnState state = SpawnState.COUNTING;


	// Use this for initialization
	void Start () {
        wave = 1;
        waveText.text = "Wave: " + (1);
        waveCountdown = timeBetweenWaves;

       
		
	}
	
	// Update is called once per frame
	void Update () {

        if (state == SpawnState.WAITING)
        {
            //Kolla om någon fiende lever
            if (!EnemyIsAlive())
            {
                //Starta nästa wave
                
                
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Dags att spawna en wave
                Debug.Log("Nu börjar en wave :D:D:D");
                StartCoroutine( SpawnWave( waves[nextWave] ) );


            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
	}

    void WaveCompleted()
    {
        Debug.Log("Alla är döda :=) :=)");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        if (nextWave + 1 > (waves.Length - 1f))
        {
            nextWave = 0;
            Debug.Log("Börjar om med waves");
        }
        wave++;
        nextWave++;
        waveText.text = "Wave: " + (nextWave + 1);


    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }             
            return true;        
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawnar wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        //Spawnshit

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);           
            yield return new WaitForSeconds(1f / _wave.spawnRate);
        }


        state = SpawnState.WAITING;

        yield break;
    }


    void SpawnEnemy(Transform _enemy)
    {
        //SPAWNA FIENDER JAO
        Instantiate(_enemy, enemySpawnPoint.position, enemySpawnPoint.rotation);
        Debug.Log("Spawning: " + _enemy.name);
    }

}
