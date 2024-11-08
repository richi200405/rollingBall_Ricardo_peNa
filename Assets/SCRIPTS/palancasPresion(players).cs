using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressurePlatePlayer : MonoBehaviour
{
    public bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player")) // Asegúrate de que el cubo tenga la etiqueta "Cube"
        {
            isActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            isActivated = false;
        }
    }
}
