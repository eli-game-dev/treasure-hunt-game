using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int _score;
    public static int NumberOfQuestions;
    public TextMeshProUGUI playerScore;
    private string playerScoreText;
    int _currentScore;


    // Use this for initialization
    void Start()
    {
        NumberOfQuestions = GameMangerQuestion.NumOfQuetions;
        playerScoreText = playerScore.text;
        playerScore.text = playerScoreText + _currentScore.ToString()+"/"+NumberOfQuestions;
    }

    // Update is called once per frame
    void Update()
    {
        if (_score != _currentScore) 
        {
            _currentScore = _score;
            playerScore.text = playerScoreText + _currentScore.ToString()+"/"+NumberOfQuestions;
        }
    }
}