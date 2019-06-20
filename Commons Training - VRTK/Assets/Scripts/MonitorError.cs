using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorError : MonoBehaviour
{    
    
    public GameObject[] childMonitors;

    private int i = 0;
    private int index;

    void Start()
    {
        index = Random.Range(0, childMonitors.Length);

        childMonitors[index].GetComponent<MonitorController>().errorState = true;
    }

    public void ErrorAll()
    {
        foreach(GameObject childMonitor in childMonitors)
        {
            childMonitors[index].GetComponent<MonitorController>().errorState = true;
        }
    }
}
