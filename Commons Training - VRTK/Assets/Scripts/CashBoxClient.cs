using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CashBoxClient : MonoBehaviour
{

    private Client client;
    public GameObject answers;
    public GameObject questions;
    private GameObject button1;
    private GameObject button2;
    private CampusCard campusCard;
    private string correctAnswer;
    private bool questionAsked = false;
    public bool questionAnswered = false;
    private bool done = false;
    private float timer = 0f;

    // Use this for initialization
    void Start() {
        client = GetComponent<Client>();
        //player = client.player;

        questions = gameObject.transform.Find("QuestionCanvas").gameObject;
        answers = gameObject.transform.Find("AnswersCanvas").gameObject;
        button1 = answers.transform.Find("Button1").gameObject;
        button2 = answers.transform.Find("Button2").gameObject;

        campusCard = GetComponentInChildren<CampusCard>();

        questions.SetActive(false);
        answers.SetActive(false);

    }

    // Update is called once per frame
    void Update() {

        if (client.askingQuestion && !questionAsked && timer <= 0 && !done)
        {
            //answers.SetActive(true);

            questions.GetComponentInChildren<TextMeshProUGUI>().text = "Excuse me, can you check if there is an issue with my campus card? Please try my card at the cash box.";

            button1.GetComponentInChildren<TextMeshProUGUI>().text = "The campus card is expired";
            button2.GetComponentInChildren<TextMeshProUGUI>().text = "The campus card works and the cashbox displays a balance";


            questionAsked = true;

        }
        if (questionAnswered && questionAsked)
        {
            if ((campusCard.expired && button1.GetComponent<ButtonPress>().beingPressed) || (!campusCard.expired && button2.GetComponent<ButtonPress>().beingPressed))

            {
                questions.GetComponentInChildren<TextMeshProUGUI>().text = "Great, thanks";
                QuestionInput.ScoreIncrement();
            }
            else
            {
                questions.GetComponentInChildren<TextMeshProUGUI>().text = "Hmm...That doesn't really help.";
                QuestionInput.ScoreDecrement();
            }

            answers.SetActive(false);
            questionAsked = false;
            questionAnswered = false;
            done = true;
            timer = 10f;
        }
        if (timer <= 0 && done)
        {
            ClientManager.cashBoxReset();
            Destroy(gameObject);
        }

        timer -= Time.deltaTime;
        checkButton();
    }
    private void checkButton()
    {
        if (button1.GetComponent<ButtonPress>().beingPressed || button2.GetComponent<ButtonPress>().beingPressed)
        {
            questionAnswered = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //transform.rotation = transform.
            questions.SetActive(true);
            answers.SetActive(true);
            client.askingQuestion = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questions.SetActive(false);
            answers.SetActive(false);
            client.askingQuestion = false;
        }
    }
}