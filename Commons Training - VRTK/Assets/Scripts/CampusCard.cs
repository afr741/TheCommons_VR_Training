using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampusCard : MonoBehaviour
{
    [HideInInspector]
    public bool expired;
    Vector3 cardOriginalPosition;
    Quaternion cardOriginalOrientation;

    // Use this for initialization
    void Start()
    {
        SetState();
        cardOriginalPosition = transform.position;
        cardOriginalOrientation = transform.rotation;
    }

    void SetState()
    {
        if(Random.Range(0,2) == 1)
        {
            expired = true;
        }
        else
        {
            expired = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {

            Debug.Log("Let go of card");
            transform.position = cardOriginalPosition;
            transform.rotation = cardOriginalOrientation;

        }
    }
}
