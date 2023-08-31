using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int highScore;
    public Text scoreDisplay;
    public Text highScoreDisplay;

    void Update()
    {
        scoreDisplay.text = "Score: " + score.ToString();
        highScoreDisplay.text = "High Score: " + PlayerPrefs.GetInt("HighScoreText");
        highScore = score;

        if (PlayerPrefs.GetInt("HighScoreText") <= highScore)
        {
            PlayerPrefs.SetInt("HighScoreText", highScore);
        }
    }

    public void PickUp()
    {
        score++;
    }
}
