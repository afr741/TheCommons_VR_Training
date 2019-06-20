using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PhoneBasedQuestions : MonoBehaviour {
    
    private float timer = 0f;
    private bool done = false;
    [HideInInspector]
    public GameObject questions;
    [HideInInspector]
    public GameObject answers;
    private Client client;
    private bool questionAsked = false;
    public bool questionAnswered = false;
    public float questionDelay = 5f;
    private int randomIndex;
    private string answer;
    public GameObject ITS;
    public GameObject Labnet;
    private float newQTimer = 0f;
    private Audio audio;
    

    // Use this for initialization
    void Start () {
        questions = gameObject.transform.Find("QuestionCanvas").gameObject;
        client = GetComponent<Client>();
        questions.SetActive(false);
        audio = FindObjectOfType<Audio>();

    }

    // Update is called once per frame
    void Update()
    {
        
        //CLIENT 1 - THE NON-MC
        if (done && timer <= 0f && QuestionInput.questionsArray.Count == 0)
        {
            Destroy(gameObject);
  
        }
        if (client.askingQuestion && !questionAsked && timer <= -5f)
        {
            client.gameObject.GetComponent<MeshRenderer>().enabled = true;
            randomIndex = Random.Range(0, QuestionInput.questionsArray.Count);
            questions.GetComponentInChildren<TextMeshProUGUI>().text = QuestionInput.questionsArray[randomIndex];
            answer = QuestionInput.answersArray[randomIndex];
            if (QuestionInput.questionsArray[randomIndex] == "My files aren't showing up on my desktop when I login!")
                audio.noFilesSound();
            if (QuestionInput.questionsArray[randomIndex] == "My balance is negative but I've never printed anything before?")
                audio.balanceNegativeSound();
            if (QuestionInput.questionsArray[randomIndex] == "I cannot login into your computers or my.mun.ca. I tried reseting my password but that does not work.")
                audio.noLoginSound();
            if (QuestionInput.questionsArray[randomIndex] == "None of my email is showing up in my inbox for MUNmail. I used to be staff.")
                audio.noEmailSound();
            questionAsked = true;
        }

        if (questionAnswered && questionAsked)
        {
                if ((answer == "LabNet" && Labnet.GetComponent<PhoneGrab>().isGrabbed) || (answer == "ITS" && Labnet.GetComponent<PhoneGrab>().isGrabbed))
                {
                    questions.GetComponentInChildren<TextMeshProUGUI>().text = "Great, thanks";
                    QuestionInput.ScoreIncrement();         
                }

                else
                {
                    questions.GetComponentInChildren<TextMeshProUGUI>().text = "Hmm...That doesn't really help.";
                    QuestionInput.ScoreDecrement();

                }

                QuestionInput.questionsArray.RemoveAt(randomIndex);
                QuestionInput.answersArray.RemoveAt(randomIndex);
                questionAsked = false;
                questionAnswered = false;
                done = true;     
                timer = questionDelay;
        }
            
        timer -= Time.deltaTime;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            questions.SetActive(true);
            client.askingQuestion = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questions.SetActive(false);
            client.askingQuestion = false;

            if (QuestionInput.questionAnswered)
            {
                Vector3 move = new Vector3(100.0f, 0, 0);
                transform.position += move;
                QuestionInput.questionAnswered = false;
            }
        }
    }




}
