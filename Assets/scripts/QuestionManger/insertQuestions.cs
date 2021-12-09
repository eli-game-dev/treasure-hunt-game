using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insertQuestions : MonoBehaviour
{
    [SerializeField] private InputField questionText;
    [SerializeField] private InputField answerRedText;
    [SerializeField] private InputField answerBlueText;
    [SerializeField] private InputField answerOrangeText;
    [SerializeField] private InputField answerGreenText;
    [SerializeField] Dropdown m_Dropdown;
    public GameObject UIQuestionAdded;
    [SerializeField] private int timeObjectActive;
    
    public void AddQuestion()
    {
        Question q = new Question();
        q.question = questionText.text;
        q.blueAnswer = answerBlueText.text;
        q.redAnswer = answerRedText.text;
        q.orangeAnswer = answerOrangeText.text;
        q.greenAnswer = answerGreenText.text;
        q.trueColor = (Question.AnsColors) m_Dropdown.value;
       // GameMangerQuestion.questions.Add(q);
        StartCoroutine(setActiveForSomeSecond(UIQuestionAdded));
    }

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private IEnumerator setActiveForSomeSecond(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(timeObjectActive);
        obj.SetActive(false);
    }
    
}