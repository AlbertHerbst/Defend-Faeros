using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

    public float difficultyMultiplier, wave;
    public Text waveText;


	// Use this for initialization
	void Start () {
        wave = 1f;
        waveText.text = "Wave: " + wave;
       
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    /*System.Timers.Timer LeTimer;
int BoomDown = 100;
void Start ()
{
    //Initialize timer with 1 second intervals
    LeTimer = new System.Timers.Timer (1000);
    LeTimer.Elapsed +=
        //This function decreases BoomDown every second
        (object sender, System.Timers.ElapsedEventArgs e) => BoomDown--;
}

void Update ()
{
    //When BoomDown reaches 0, BOOM!
    if (BoomDown <= 0)
        Debug.Log ("Boom!");
}*/
}
