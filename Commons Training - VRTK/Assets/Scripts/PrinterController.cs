using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrinterController : MonoBehaviour
{
    private bool full = false;
    public TextMeshProUGUI output;
    private const float resetTimer = 20f;
    private float timer = 0;

    private void Start()
    {
        output.text = "Empty";
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(full && timer<=0)
        {
            full = false;
            output.text = "Empty";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paper") && !full)
        {
            output.text = "Full";
            full = true;
            Destroy(other.gameObject);
            timer = resetTimer;
        }
    }
}
