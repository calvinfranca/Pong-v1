using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Ball ballBase;
    public float resetTime = 1f;
    public static GameManager Instance;
    [Header("Menus")]
    public GameObject uiGameOver;

    [Header("Players")]
    public Player player1;
    public Player player2;

    public TextMeshProUGUI winnerText;


    private void Awake()
    {
        Instance = this;
    }

    public void ResetPlayers()
    {
        player1.ResetPlayer();
        player2.ResetPlayer();

    }

    public void Update()
    {
        
    }

    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), resetTime);
        Invoke(nameof(SwitchToPlaying), resetTime);
        

    }

    public void SetBallFree()
    {
        ballBase.CanMove(true);
    }

    public void StartGame()
    {
        
        ballBase.CanMove(true);
        ballBase.RandomBall();
    }

    public void SwitchToPlaying()
    {
        StateManager.Instance.SwitchState(StateManager.States.PLAYING);
    }

    public void ShowGameOver()
    {
        if (player1.currentPoints > player2.currentPoints)
        {
            winnerText.text = player1.playerName + " is the winner!";
        }
        else
            winnerText.text = player2.playerName + " is the winner!";

        ballBase.CanMove(false);
        uiGameOver.SetActive(true);

    }

    public void GameOver()
    {
        StateManager.Instance.SwitchState(StateManager.States.GAME_OVER);
    }

    public void ResetPoints()
    {
        player1.currentPoints = 0;
        player2.currentPoints = 0;

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
