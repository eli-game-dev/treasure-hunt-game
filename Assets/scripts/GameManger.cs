using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor.Experimental.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManger : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unAnsweredYet;
    private Question currentQuestion;
    public GameObject player;

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


    void Start()
    {
        if (unAnsweredYet == null || unAnsweredYet.Count == 0)
        {
            unAnsweredYet = questions.ToList();
        }

        canClick = true;
        SetCurrenQuestion();
    }

    void SetCurrenQuestion()
    {
        if (unAnsweredYet.Count > 0)
        {
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
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
        SetCurrenQuestion();
    }

    private void WorngAnswer()
    {
        Debug.Log("Worng answer");
        Debug.Log("Wait.");
        StartCoroutine(WaitToNextClick());
        canClick = false;
        player.GetComponent<KeyboardMover>().SetCanMove(false);
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
        player.GetComponent<KeyboardMover>().SetCanMove(true);
        canClick = true;
    }

    private IEnumerator setActiveForSomeSecond()
    {
        correctAnswerUI.SetActive(true);
        yield return new WaitForSeconds(timeObjectActive);
        correctAnswerUI.SetActive(false);
    }
}