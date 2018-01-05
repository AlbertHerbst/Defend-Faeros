using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


//The ScoreManager takes care of all the value management in the game. (Currently money and lives)
public class ScoreManager : MonoBehaviour {

    public int lives = 20;

    public int money = 100;

    public TextMeshProUGUI moneyText;

    public TextMeshProUGUI livesText;


	public void LooseLife(int l = 1)
    {
        lives -= l;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        //TODO: Create A Game Over screen which the player gets sent to.
        Debug.Log("Game Over!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        //FIXME: This doesn't actually need to update every frame.

        moneyText.text = "Money: " + money.ToString();
        livesText.text = "Lives: " + lives.ToString();


    }
}
