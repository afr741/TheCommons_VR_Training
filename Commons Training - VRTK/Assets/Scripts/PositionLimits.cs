using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLimits : MonoBehaviour
{
    private Quaternion startRotation;
    private float startY;
    public float minX;
    public float minZ;
    private float maxX;
    private float maxZ;
    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
        startY = transform.localPosition.y;
        maxX = transform.localPosition.x;
        maxZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = startRotation;
        if(transform.localPosition.x <= minX)
        {
            transform.localPosition = new Vector3(minX, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.z <= minZ)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, minZ);
        }


        if (transform.localPosition.x > maxX)
        {
            transform.localPosition = new Vector3(maxX, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.z > maxZ)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, maxZ);
        }
    }
}
