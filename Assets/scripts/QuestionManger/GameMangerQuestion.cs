using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Random = UnityEngine.Random;

public class GameMangerQuestion : MonoBehaviourPunCallbacks 
{
    [SerializeField] 
    public List<Question> questions;
    public static int NumOfQuetions;
    public static List<Question> unAnsweredYet;
    private Question currentQuestion;
    //public GameObject player;

    [SerializeField] private Text questionText;
    [SerializeField] private Text answerRedText;
    [SerializeField] private Text answerBlueText;
    [SerializeField] private Text answerOrangeText;
    [SerializeField] private Text answerGreenText;

    private bool canClick;
    public GameObject cube;

    public Text worngText;

    // public Text correctText;
    public GameObject worngAnswerUI;
    public GameObject correctAnswerUI;
    [SerializeField] private int timeObjectActive;

    //[SerializeField] private float timeBtweenQuestion = 1f;
    [SerializeField] private int timePlayerfreeze = 5;

    private void Awake()
    {
        NumOfQuetions = questions.Count;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        // questions = new List<Question>(); 
        // questions.Add(q);

        if (unAnsweredYet == null || unAnsweredYet.Count == 0)
        {
            unAnsweredYet = questions;
            Debug.Log("unAnsweredYet list");
        }

        canClick = true;
        SetCurrenQuestion();
    }

    void SetCurrenQuestion()
    {
        if (unAnsweredYet.Count > 0)
        {
            Debug.Log("new question"+unAnsweredYet.Count);
            int randomQuestion = Random.Range(0, unAnsweredYet.Count);
            currentQuestion = unAnsweredYet[randomQuestion];
            questionText.text = currentQuestion.question;
            answerRedText.text = currentQuestion.redAnswer;
            answerBlueText.text = currentQuestion.blueAnswer;
            answerOrangeText.text = currentQuestion.orangeAnswer;  
            answerGreenText.text = currentQuestion.greenAnswer;
            unAnsweredYet.RemoveAt(randomQuestion); 
        }
        else
        {
            PhotonNetwork.AutomaticallySyncScene = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }

    public void PlayerSelectRed()
    {
        if (canClick)
        {
            if (currentQuestion.trueColor == Question.AnsColors.Red)
            {
                CorrectAnswer();
            }
            else
            {
                WorngAnswer();
            }
        }
    }

    public void PlayerSelectBlue()
    {
        if (canClick)
        {
            if (currentQuestion.trueColor == Question.AnsColors.Blue)
            {
                CorrectAnswer();
            }
            else
            {
                WorngAnswer();
            }
        }
    }

    public void PlayerSelectOrange()
    {
        if (canClick)
        {
            if (currentQuestion.trueColor == Question.AnsColors.Orange)
            {
                CorrectAnswer();
            }
            else
            {
                WorngAnswer();
            }
        }
    }

    public void PlayerSelectGreen()
    {
        if (canClick)
        {
            if (currentQuestion.trueColor == Question.AnsColors.Green)
            {
                CorrectAnswer();
            }
            else
            {
                WorngAnswer();
            }
        }
    }

    private void CorrectAnswer()
    {
        Debug.Log("CORRECT!");
        StartCoroutine(setActiveForSomeSecond());
        cube.GetComponent<interact>().setAnswred(true);
        Score._score++;
        SetCurrenQuestion();
    }

    private void WorngAnswer()
    {
        Debug.Log("Worng answer");
        Debug.Log("Wait.");
        StartCoroutine(WaitToNextClick());
        canClick = false;
        PlayerMover.LocalPlayerInstance.GetComponent<PlayerMover>().SetCanMove(false);
    }

    private IEnumerator WaitToNextClick()
    {
        int count = timePlayerfreeze;
        while (count > 0)
        {
            worngAnswerUI.SetActive(true);
            worngText.text = "Worng Answer wait " + timePlayerfreeze + " seconds:" + count.ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }

        worngAnswerUI.SetActive(false);
        Debug.Log("Finished waiting.");
        PlayerMover.LocalPlayerInstance.GetComponent<PlayerMover>().SetCanMove(true);
        canClick = true;
    }

    private IEnumerator setActiveForSomeSecond()
    {
        correctAnswerUI.SetActive(true);
        yield return new WaitForSeconds(timeObjectActive);
        correctAnswerUI.SetActive(false);
    }
}