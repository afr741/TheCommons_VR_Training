using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RobotController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public static bool isTouchingUSB;
    public static bool isInUsbBox;
    public GameObject robotCanvas;



    void Start()
    {
       // offset = new Vector3(0, 0, 3f);
        robotCanvas = gameObject.transform.Find("RobbieCanvas").gameObject;
        isTouchingUSB = false;
        isInUsbBox = false;

        robotCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "Hello There! I am the Robbie, the droid assigned to guide you through this complex ";
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = player.transform.position + offset;          

        //display robot canvas with tips about USB
        if (isTouchingUSB==true)
        {
            robotCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "oh wow, you found a lost usb, now you gotta find a USB Box where you can store it";    
        }

        if (isInUsbBox==true)
        {
            robotCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "Good Job! Continue doing rounds...";
        }

       
    }
}
