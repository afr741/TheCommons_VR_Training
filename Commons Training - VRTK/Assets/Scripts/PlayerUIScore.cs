using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;


public class PlayerUIScore : MonoBehaviour
{
    TextMeshProUGUI playerUIscore;
    public static Canvas mainCanvas;


    void Start()
    {
        playerUIscore = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        mainCanvas = gameObject.GetComponent<Canvas>();
        mainCanvas.enabled = false;
    }

    void Update()
    {
        playerUIscore.SetText("Pro:0" + "\nTech:0" + "\nC-Srv:0" + "\ntotal:  " + QuestionInput.totalScore.ToString());

        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            mainCanvas.enabled = !mainCanvas.enabled;
        }
    }
}

