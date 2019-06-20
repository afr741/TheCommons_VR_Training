using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class MCQuestions : MonoBehaviour {
    private Client client;
    [HideInInspector]
    public GameObject questions;
    [HideInInspector]
    public GameObject answers;
    private GameObject button1;
    private GameObject button2;
    private GameObject button3;
    private GameObject button4;
    private List<string> output;
    private Transform player;
    private string correctAnswer;
    private int randomIndex;
    private bool questionAsked = false;
    public bool questionAnswered = false;
    private bool done = false;
    public float questionDelay = 10f;
    private float timer = 0f;
    private AudioSource audioSource;
    private string pathStart = "Audio/";
    private AudioClip questionAudio;
   // private PlayerUIScore uiScoreScript;



    // Use this for initialization
    void Start()
    {        
        client = GetComponent<Client>();
        player = client.player;
        audioSource = GetComponent<AudioSource>();
       
        questions = gameObject.transform.Find("QuestionCanvas").gameObject; 
        answers = gameObject.transform.Find("AnswersCanvas").gameObject;  
        output = new List<string> { };
        questions.SetActive(false);
        answers.SetActive(false);
        button1 = answers.transform.Find("Button1").gameObject;
        button2 = answers.transform.Find("Button2").gameObject;
        button3 = answers.transform.Find("Button3").gameObject;
        button4 = answers.transform.Find("Button4").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if(done && timer <= 0f)
        {
            client.gameObject.SetActive(false);
        }
        if (client.askingQuestion && !questionAsked && timer <= 0)
        {
            //answers.SetActive(true);
            randomIndex = Random.Range(0, QuestionInput.mcCorrectAnswers.Count);
            questions.GetComponentInChildren<TextMeshProUGUI>().text = "Excuse me, " + QuestionInput.mcQuestions[randomIndex];
            output = new List<string> { };

            output.Add(QuestionInput.mcCorrectAnswers[randomIndex]);
            output.Add(QuestionInput.mcWrongAnswers[randomIndex][0]);
            output.Add(QuestionInput.mcWrongAnswers[randomIndex][1]);
            output.Add(QuestionInput.mcWrongAnswers[randomIndex][2]);
            string audioName = QuestionInput.mcAudio[randomIndex].TrimEnd('\n', '\r');
            if (!audioName.Equals("none"))
            {
                questionAudio = Resources.Load(pathStart + audioName) as AudioClip;
                audioSource.clip = questionAudio;
                audioSource.Play();
            }
            else
            {
                Debug.Log("No audio clip assigned for question");
            }
            output = Shuffle(output);

            
            button1.GetComponentInChildren<TextMeshProUGUI>().text = output[0];
            button2.GetComponentInChildren<TextMeshProUGUI>().text = output[1];
            button3.GetComponentInChildren<TextMeshProUGUI>().text = output[2];
            button4.GetComponentInChildren<TextMeshProUGUI>().text = output[3];
            correctAnswer = QuestionInput.mcCorrectAnswers[randomIndex];        
            questionAsked = true;
        }
        if (questionAnswered && questionAsked)
        {
            if ((output[0] == correctAnswer && button1.GetComponent<ButtonPress>().beingPressed) || (output[1] == correctAnswer && button2.GetComponent<ButtonPress>().beingPressed) ||
                (output[2] == correctAnswer && button3.GetComponent<ButtonPress>().beingPressed) || (output[3] == correctAnswer && button4.GetComponent<ButtonPress>().beingPressed))
            {
                questions.GetComponentInChildren<TextMeshProUGUI>().text = "Great, thanks";
                QuestionInput.ScoreIncrement(2);
            }

            else
            {
                questions.GetComponentInChildren<TextMeshProUGUI>().text = "Hmm...That doesn't really help.";
                QuestionInput.ScoreDecrement(2);
            }

            QuestionInput.mcQuestions.RemoveAt(randomIndex);
            QuestionInput.mcCorrectAnswers.RemoveAt(randomIndex);
            QuestionInput.mcWrongAnswers.RemoveAt(randomIndex);
            answers.SetActive(false);
            questionAsked = false;
            questionAnswered = false;
            done = true;
            timer = questionDelay;
        }
        timer -= Time.deltaTime;
        checkButton();

	}
    private void checkButton()
    {
        if(button1.GetComponent<ButtonPress>().beingPressed || button2.GetComponent<ButtonPress>().beingPressed ||
            button3.GetComponent<ButtonPress>().beingPressed || button4.GetComponent<ButtonPress>().beingPressed) 
        {
            questionAnswered = true;
        }
    }



    public static List<string> Shuffle(List<string> list)
    {
        List<string> shuffled = new List<string> { };

        while (list.Count > 0) //Shuffle List
        {
            int randomI = Random.Range(0, list.Count);

            shuffled.Add(list[randomI]);
            list.RemoveAt(randomI);
        }

        return shuffled;
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

            if (QuestionInput.questionAnswered)
            {
                Vector3 move = new Vector3(100.0f, 0, 0);
                transform.position += move;
                QuestionInput.questionAnswered = false;
            }
        }
    }
}
