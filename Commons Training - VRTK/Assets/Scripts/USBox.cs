using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USBox : MonoBehaviour {
    private AudioSource usbCollectedSound;
    // Use this for initialization
    void Start () {
        
    }
/*
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("USB"))
        {
            Debug.Log("collision worked");
            usbCollectedSound.Play();      //USB signal is played
            QuestionInput.ScoreIncrement();//played and the player gets a score point      
            StartCoroutine(QuestionInput.FlashPlayerScore());
            // collider.gameObject.SetActive(false);  //works only for 1 USB, others become ungrabbable
            collider.gameObject.GetComponentInChildren<Renderer>().enabled = false;
            collider.gameObject.GetComponentInChildren<Canvas>().enabled = false;
            collider.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }
    */
}
