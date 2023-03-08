using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;
    public static StartGameDelegate onPlayerDeath;
    public static StartGameDelegate onReSpawnPickUp;

    public delegate void TakeDamageDelegate(float amount);
    public static TakeDamageDelegate onTakeDamage;

    public delegate void ScorePointDelegate(int amount);
    public static ScorePointDelegate onScorePoints;


    public static void StartGame()
    {
        //Debug.Log("Start Game");
        if(onStartGame != null)
            onStartGame();
    }

    public static void SpawnPickup()
    {
        if(onReSpawnPickUp != null)
            onReSpawnPickUp();
    }

    public static void TakeDamage(float percent)
    {
        //Debug.Log("Take Damage: " + percent);
        if (onTakeDamage != null)
            onTakeDamage(percent);
    }

    public static void PlayerDeath()
    {
        //Debug.Log("Player Died");
        if (onPlayerDeath != null)
            onPlayerDeath();
    }

    public static void ScorePoints(int score)
    {
        //Debug.Log("Take Damage: " + percent);
        if(onScorePoints != null)
            onScorePoints(score);
    }
}
