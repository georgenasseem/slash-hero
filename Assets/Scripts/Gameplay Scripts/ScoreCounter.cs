using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ScoreCounter : MonoBehaviour
{

    [SerializeField]
    public Text scoreTxt;

    GameObject player;
    private PlayerMovement playerMovement;

    private int scoreCount;

    private float scoreCountTimerTreshold;
    private float scoreCountTimer;

    private bool _canCountScore;
    public bool CanCountScore
    {
        get { return _canCountScore; }
        set { _canCountScore = value; }
    }

    private StringBuilder scoreStringBuilder = new StringBuilder();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        CanCountScore = true;
        scoreCountTimer = Time.time + scoreCountTimerTreshold;
    }

    private void Update()
    {
        if (!CanCountScore)
        {
            return;
        }

        scoreCountTimerTreshold = 1 / playerMovement.moveSpeed;
        //scoreCount += Time.deltaTime;
        //scoreTxt.text = (int)scoreCount + "m";

        if (Time.time > scoreCountTimer)
        {
            scoreCountTimer = Time.time + scoreCountTimerTreshold;
            scoreCount++;
            DisplayScore(scoreCount);
        }

    }

    void DisplayScore(int score)
    {
        scoreStringBuilder.Length = 0;
        scoreStringBuilder.Append(score);
        scoreStringBuilder.Append("m");

        scoreTxt.text = scoreStringBuilder.ToString();

    }

    public int GetScore()
    {
        return scoreCount;
    }

} // class



























