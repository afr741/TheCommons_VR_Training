using UnityEngine;

public class Client : MonoBehaviour
{

    public Transform player;
    public bool askingQuestion;

    void Start()
    {        
        askingQuestion = false;
        
    }

    private void Update()
    {
       // transform.rotation = player.rotation;
    }
    
}