using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Text scoreEnd;
    public ScoreManager sm;

    private void Start()
    {
        scoreEnd.text = "Score: " + sm.score.ToString();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
