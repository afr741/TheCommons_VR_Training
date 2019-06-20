using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobbieFollow : MonoBehaviour
{
    public GameObject player;
    public float targetDistance;
    public float allowedDistance = 3;   
    private float speed = 0.1f;
    public RaycastHit shot;
    
    void Update()
    {
        transform.LookAt(player.transform);
        if(Vector3.Distance(transform.position, player.transform.position) > allowedDistance)    
        {
            PathFind();
            transform.position += transform.forward * Time.deltaTime;
        }
    }
    void PathFind()
    {
        if(GetComponent<Rigidbody>().SweepTest(transform.TransformDirection(Vector3.forward), out shot, 2))
        {
            transform.Rotate(0, 1, 0);
            PathFind();
        }
        return;
    }
}
