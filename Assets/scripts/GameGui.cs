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

    public GameObject VCOpening;

    public void showStart()
    {
        VCOpening.SetActive(true);

    }

    public void guiSetUp()
        // this function should be called once we start the game 
    {

        VCOpening.SetActive(false);

        //Text text1 = GameObject.FindGameObjectWithTag("playerOneWrapper").GetComponentInChildren<Text>();
        //Text text2 = GameObject.FindGameObjectWithTag("playerTwoWrapper").GetComponentInChildren<Text>();

        //text1.text = "What are you looking for?";
        //text2.text = "What are you looking for?";

     }

    public void blackPlayerRiminder()
    {
        Text text2 = GameObject.FindGameObjectWithTag("playerTwoWrapper").GetComponentInChildren<Text>();

        text2.text = "Try pressing SpaceBar to Draw a Trail";

    }

    public void blackWhiteRiminder()
    {
        Text text2 = GameObject.FindGameObjectWithTag("playerTwoWrapper").GetComponentInChildren<Text>();

        text2.text = "Try pressing M to do a pulse";

    }

    public void win()
    {
        Text text1 = GameObject.FindGameObjectWithTag("playerOneWrapper").GetComponentInChildren<Text>();
        Text text2 = GameObject.FindGameObjectWithTag("playerTwoWrapper").GetComponentInChildren<Text>();

        text1.text = "win";
        text2.text = "win";
    }

    public void lose()
    {
        Text text1 = GameObject.FindGameObjectWithTag("playerOneWrapper").GetComponentInChildren<Text>();
        Text text2 = GameObject.FindGameObjectWithTag("playerTwoWrapper").GetComponentInChildren<Text>();

        text1.text = "lose";
        text2.text = "lose";
    }
}
