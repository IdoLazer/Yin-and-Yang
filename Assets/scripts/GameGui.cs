using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGui : MonoBehaviour
{  
    private Camera player1Cam;
    private Camera player2Cam;

    private float startTime;
    private float pulseTime;
    private float TrailTime;

    private Text text1;
    private Text text2;



    public void guiSetUp()
        // this function should be called once we start the game 
    {
        startTime = Time.deltaTime;
        pulseTime = startTime;
        TrailTime = startTime;

        player1Cam = GameObject.FindGameObjectWithTag("Player1").GetComponent<Camera>();
        player2Cam = GameObject.FindGameObjectWithTag("Player2").GetComponent<Camera>();

        Text text1 = GameObject.FindGameObjectWithTag("Player1").GetComponentInChildren<Text>();
        Text text2 = GameObject.FindGameObjectWithTag("Player2").GetComponentInChildren<Text>();

        text1.text = "What are you looking for?";
        text2.text = "What are you looking for?";

     }

    public void blackPlayerRiminder()
    {
        Text text2 = GameObject.FindGameObjectWithTag("Player2").GetComponentInChildren<Text>();

        text2.text = "Try pressing SpaceBar to Draw a Trail";

    }

    public void blackWhiteRiminder()
    {
        Text text2 = GameObject.FindGameObjectWithTag("Player2").GetComponentInChildren<Text>();

        text2.text = "Try pressing M to do a pulse";

    }

    public void win()
    {
        Text text1 = GameObject.FindGameObjectWithTag("Player1").GetComponentInChildren<Text>();
        Text text2 = GameObject.FindGameObjectWithTag("Player2").GetComponentInChildren<Text>();

        text1.text = "win";
        text2.text = "win";
    }

    public void lose()
    {
        Text text1 = GameObject.FindGameObjectWithTag("Player1").GetComponentInChildren<Text>();
        Text text2 = GameObject.FindGameObjectWithTag("Player2").GetComponentInChildren<Text>();

        text1.text = "lose";
        text2.text = "lose";
    }
}
