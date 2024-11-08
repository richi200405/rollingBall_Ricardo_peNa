using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public PressurePlate plate1; // Asigna la primera palanca en el Inspector
    public PressurePlate plate2; // Asigna la segunda palanca en el Inspector
    public PressurePlatePlayer plateplayer1; // Asigna la primera palanca en el Inspector
    public PressurePlatePlayer plateplayer2; // Asigna la segunda palanca en el Inspector
    public float openHeight = 3f; // Altura a la que se abrirá la puerta
    public float openSpeed = 2f;  // Velocidad de apertura

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.up * openHeight;
    }

    void Update()
    {
        //plate1.isActivated && plate2.isActivated ||
        if ( plateplayer1.isActivated && plateplayer2.isActivated)
        {
            OpenDoor();
        }
        else if (plate1.isActivated && plate2.isActivated) 
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
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
}
