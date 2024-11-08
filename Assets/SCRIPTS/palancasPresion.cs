using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressurePlate : MonoBehaviour
{
    public bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cube")) // Asegúrate de que el cubo tenga la etiqueta "Cube"
        {
            isActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cube"))
        {
            isActivated = false;
        }
    }
}
