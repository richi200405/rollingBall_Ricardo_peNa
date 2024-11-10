using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorController3 : MonoBehaviour
{

    
    public GameObject llavetext;

    public llavefinal llave; // Asigna la primera palanca en el Inspector
    public llavefinal llave2; // Asigna la primera palanca en el Inspector

    public float openHeight = 3f; // Altura a la que se abrirá la puerta
    public float openSpeed = 2f;  // Velocidad de apertura

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.down * openHeight;

        llavetext.SetActive(false);
    }

    void Update()
    {
        //plate1.isActivated && plate2.isActivated ||

        //if (llave.isActivated)
        //{
        //    OpenDoor();
        //}
        //else
        //{
        //    CloseDoor();
        //}
    }

    void OpenDoor()
    {
        if (!isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, openSpeed * Time.deltaTime);
            if (transform.position == openPosition)
            {
                isOpen = true;
            }
        }
    }

    void CloseDoor()
    {
        if (isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, openSpeed * Time.deltaTime);
            if (transform.position == closedPosition)
            {
                isOpen = false;
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("player") && llave.isActivated && llave2.isActivated)
        {
            OpenDoor();
        }
        else if (other.gameObject.CompareTag("player") && llave.isActivated == false && llave2.isActivated == false)
        {
            llavetext.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            llavetext.SetActive(false);
        }      
    }


       
    
}
