﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public enum State
    {
        Start,
        Game,
        Win,
        Lose,
    }

    public instantiating init;
    private State state;
    private static bool IsPaused = false;
    private GameObject player1;
    private GameObject player2;
    private float distanceBetween;
    private GameGui myGui;
    private DisplayScript display;

    private bool playerOneReady = false;
    private bool playerTwoReady = false;



    void Start()
    {
        state = State.Start;
        
        display = GetComponent<DisplayScript>();
        display.StartDisplay();
        
        myGui = GetComponent<GameGui>();
        myGui.showStart();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Start:

                PressToStartGame();
                break;

            case State.Game:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    shouldPaue();

                }
                
                if (player1.GetComponent<PlayerScript>().playerLife < 0)
                {

                    state = State.Lose;
                }
               
                distanceBetween = Vector3.Distance(player1.transform.position, player2.transform.position);
                if (distanceBetween < 7)
                {
                    myGui.win();   
                    state = State.Win;
                }

                break;
            case State.Win:
                myGui.win();
                clearPieces();
                player1.GetComponent<PlayerScript>().restart();
                myGui.showStart();
                state = State.Start;

                break;

            case State.Lose:
                myGui.lose();
                clearPieces();
                player1.GetComponent<PlayerScript>().restart();
                myGui.showStart();

                state = State.Start;
                break;

        }
    }

    void StartGame()
    {
        // SceneManager.LoadScene("signaling sandbox 2");
        init.loadPlayers();
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

    }

    public void PressToStartGame()
    {
        if (Input.GetKey(KeyCode.S))
        {
            playerOneReady = true;
        }

        if (Input.GetKey(KeyCode.T))
        {
            playerTwoReady = true;
        }

        if ((playerOneReady & playerTwoReady))
        {
            state = State.Game;
            myGui.guiSetUp();
            StartGame();
        }
    }

    void shouldPaue()
    {
        if (IsPaused)
        {
            Resume();
        }

        else
        {
            Pause();
        }
    }

    void Resume()
    {

        //myGui.resume()
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause()
    {
        //myGui.pause()
        Time.timeScale = 0.0f;
        IsPaused = true;

    }

    public State getState()
    {
        return state;
    }

    public void clearPieces()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Piece");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }


}
