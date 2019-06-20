using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PhoneGrab : MonoBehaviour {
    public Vector3 phoneOriginalPosition;
    public Quaternion phoneOriginalRotation;
   
    void Start()
    {

        phoneOriginalPosition = transform.position;
        phoneOriginalRotation = transform.rotation;
        
    }

    public bool isGrabbed = false;
   
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            GameObject.Find("ClientDesk").GetComponent<PhoneBasedQuestions>().questionAnswered = true;
           
            isGrabbed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isGrabbed = false;
            GameObject.Find("ClientDesk").GetComponent<PhoneBasedQuestions>().questionAnswered = false;

            
            transform.position = phoneOriginalPosition;
            transform.rotation = phoneOriginalRotation;

        }
    }

}
