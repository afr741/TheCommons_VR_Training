using UnityEngine;
using TMPro;


public class WrongAnswers : MonoBehaviour
{
    private TextMeshProUGUI wrongOutput;


    void Start()
    {
        wrongOutput = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        wrongOutput.text = QuestionInput.wrong.ToString();

    }
}

