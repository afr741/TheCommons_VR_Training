using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundsLight : MonoBehaviour {

    public bool isDone = false;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

}
