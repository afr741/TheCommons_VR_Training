using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundsCard : MonoBehaviour {

    private AudioSource singleRoundSignal;
    // Use this for initialization
    
    private void Start()
    {
        singleRoundSignal = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Station"))
        {
            RoundsLight station = other.gameObject.GetComponent<RoundsLight>();
            if (!station.isDone)
            {
                singleRoundSignal.Play();
                station.gameObject.GetComponent<Renderer>().material.color = Color.green;
                station.isDone = true;
                Rounds.checkRounds();
            }
        }        
    }
}
