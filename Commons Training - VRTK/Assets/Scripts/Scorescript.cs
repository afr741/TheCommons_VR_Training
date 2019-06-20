using UnityEngine;
using TMPro;

public class Scorescript : MonoBehaviour {

    private TextMeshProUGUI uiScorescript;
    void Start()
    {
        uiScorescript = gameObject.GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {

        uiScorescript.text = QuestionInput.correct.ToString();


    }
}
