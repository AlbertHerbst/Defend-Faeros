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

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;


    public float difficultyMultiplier, wave;
    public Text waveText;

    private SpawnState state = SpawnState.COUNTING;


	// Use this for initialization
	void Start () {
        wave = 1f;
        waveText.text = "Wave: " + wave;
        waveCountdown = timeBetweenWaves;

       
		
	}
	
	// Update is called once per frame
	void Update () {
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Dags att spawna en wave

                StartCoroutine( SpawnWave( waves[nextWave] ) );


            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
	}

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        //Spawnshit

        for (int i = 0; i < _wave.count; i++)
        {

        }


        state = SpawnState.WAITING;

        yield break;
    }


}
