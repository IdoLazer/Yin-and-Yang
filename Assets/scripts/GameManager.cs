using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private enum State
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
    
    private float startTime;

    void Start()
    {
        state = State.Start;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Start:
                
                Debug.Log("start");
                StartGame();
                break;

            case State.Game:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    shouldPaue();

                }

                break;
            case State.Win:
                Debug.Log("win");
                break;
            case State.Lose:
                Debug.Log("Lose");
                break;

        }
    }

    void StartGame()
    {
        init.loadPlayers();
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        startTime = init.startTime;
        state = State.Game;

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

        //PauseScene.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        //PauseScene.SetActive(false);
    }

    void Pause()
    {
        //PauseScene.SetActive(true);
        Time.timeScale = 0.0f;
        IsPaused = true;
        //PauseScene.SetActive(true);

    }
}
