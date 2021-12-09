

[System.Serializable]
public class Question
{
    public enum AnsColors {Red, Blue, Orange, Green};
    public string question;
    public string redAnswer;
    public string blueAnswer;
    public string orangeAnswer;
    public string greenAnswer; 
    public AnsColors trueColor;
}
