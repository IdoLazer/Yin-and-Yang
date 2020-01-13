using System.Collections;
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
    
    void Start()
    {
        state = State.Start;
        display = GetComponent<DisplayScript>();
        display.StartDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Start:

                //myGui.showStart();
                // this case will be in charge of pulling up the opening scene and when we press start in the scene it will change 
                // the state = State.Game; which will start the game
                state = State.Game;
                StartGame();

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
                Debug.Log(distanceBetween);
                if (distanceBetween < 7)
                {
                    myGui.win();   
                    state = State.Win;
                }

                break;
            case State.Win:
                //myGui.winScene();
                break;

            case State.Lose:
                myGui.lose();
                break;

        }
    }

    void StartGame()
    {
        // SceneManager.LoadScene("signaling sandbox 2");
        init.loadPlayers();
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        myGui = GetComponent<GameGui>();
        myGui.guiSetUp();


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

    public void LoadMenu()
    {

        SceneManager.LoadScene("OpeningScene");
    }

    public State getState()
    {
        return state;
    }
}
