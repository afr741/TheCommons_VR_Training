using UnityEngine;
using TMPro;


public class CorrectAnswers : MonoBehaviour {
    
    private TextMeshProUGUI correctOutput;

    void Start()
    {
          correctOutput = gameObject.GetComponent<TextMeshProUGUI>();
        
    }

    void Update()
    {

         correctOutput.text = QuestionInput.correct.ToString();
    
        
    }
}
