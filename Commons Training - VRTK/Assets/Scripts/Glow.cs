using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    private Light glow;
    private int multiplier = 3;
    // Start is called before the first frame update
    void Start()
    {
        glow = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((glow.intensity >= 1 && multiplier > 0) || (glow.intensity <= 0.01 && multiplier < 0))
        {
            multiplier *= -1;
        }
        glow.intensity += multiplier*Time.deltaTime;
    }
}
