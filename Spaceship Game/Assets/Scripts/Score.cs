using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;


    [SerializeField] int score;
    [SerializeField] int highScore;



    void OnEnable()
    {
        EventManager.onStartGame += ResetScore;
        EventManager.onPlayerDeath += LoadHighScore;
        EventManager.onPlayerDeath += CheckNewHighScore;
        EventManager.onScorePoints += AddScore;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= ResetScore;
        EventManager.onPlayerDeath -= LoadHighScore;
        EventManager.onPlayerDeath -= CheckNewHighScore;
        EventManager.onScorePoints -= AddScore;
    }

    void ResetScore()
    {
        score = 0;
        DisplayScore();
    }

    void AddScore(int amount)
    {
        score += amount;
        DisplayScore();
    }

    void DisplayScore()
    {
        scoreText.text = score.ToString();
    }

    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        DisplayHighScore();
    }

    void CheckNewHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            DisplayHighScore();
        }
    }

    void DisplayHighScore()
    {
        highScoreText.text = highScore.ToString();
    }
}
