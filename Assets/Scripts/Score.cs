using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    private Text scoreText;

    private static int score; //Keep score throughout the game;

    private void Awake()
    {
        scoreText = GetComponent<Text>(); // Gather the text component on this object
        //score = 0; //Reset Score at start of level
        scoreText.text = "Score:" + score;//Update displayed score
    }


    public void addScore()
    {
        score++; //Increase score by 1;
        scoreText.text = "Score:" + score; //Update displayed score
    }

    public void subtractScore()
    {
        score--; //Decrease score by 1;
        scoreText.text = "Score:" + score;//Update displayed score
    }

    public int getScore()
    {
        return score;
    }

    public void setScore(int newScore)
    {
        scoreText = GetComponent<Text>();
        score = newScore;
        scoreText.text = "Score:" + score;
    }
}

