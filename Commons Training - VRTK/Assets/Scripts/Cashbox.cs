using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cashbox : MonoBehaviour
{
    private TextMeshPro displayText;
    private float textTimer = 0f;
    private string startingMessage = "Please insert your card";
    // Use this for initialization
    void Start()
    {
        displayText = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        textTimer -= Time.deltaTime;
        if(textTimer <= 0f)
        {
            displayText.text = startingMessage;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CampusCard"))
        {
            if (other.GetComponent<CampusCard>().expired)
            {
                displayText.text = "Expired";
            }
            else
            {
                displayText.text = "Balance: $500";
            }
            textTimer = 5f;
        }
        
    }
}

