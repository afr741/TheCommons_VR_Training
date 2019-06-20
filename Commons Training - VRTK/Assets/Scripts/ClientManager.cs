using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour {
    [HideInInspector]
    static private bool cashBoxClientAlive = false;
    [HideInInspector]
    static private float cashBoxTimer = 15f;
    [HideInInspector]
    static private float cashBoxTimerReset = 15f;
    public GameObject cashBoxClient;

	void Update () {
        if (!cashBoxClientAlive && cashBoxTimer <= 0f)
        {
            Instantiate(cashBoxClient, cashBoxClient.transform.position, cashBoxClient.transform.rotation);
            cashBoxClientAlive = true;        }
        cashBoxTimer -= Time.deltaTime;
	}

    static public void cashBoxReset()
    {
        cashBoxClientAlive = false;
        cashBoxTimer = cashBoxTimerReset;

    }
}
