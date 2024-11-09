using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressurePlatePlayer2 : MonoBehaviour
{
   

    public bool isActivated = false;


    void Start()
    {
        
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player2") 
        {
            isActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "player2")
        {
            isActivated = false;
        }
    }
}
