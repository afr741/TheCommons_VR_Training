using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{

    // User Inputs
    public float amplitude = 0.5f;
    public float frequency = 1f;

    // Position Storage Variables
    float posOffset;
    float tempPos;


    // Start is called before the first frame update
    void Start()
    {
        // Store the starting position & rotation of the object
          posOffset = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = new Vector3(transform.position.x, tempPos, transform.position.z);
    }
}





