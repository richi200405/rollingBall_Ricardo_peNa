using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlataformaMovil : MonoBehaviour
{
    // Variables p�blicas para ajustar desde el Inspector
    public Vector3 direccion = Vector3.right; // Direcci�n de movimiento (ej: derecha)
    public float velocidad = 2f; // Velocidad de movimiento
    public float distancia = 5f; // Distancia total que recorrer�

    // Variables privadas para el seguimiento de la posici�n inicial
    private Vector3 posicionInicial;
    private bool moviendoHaciaPosicionInicial = false;

    private void Start()
    {
        // Guarda la posici�n inicial de la plataforma
        posicionInicial = transform.position;
    }

    private void Update()
    {
        // Determina la distancia recorrida desde la posici�n inicial
        float distanciaRecorrida = Vector3.Distance(posicionInicial, transform.position);

        // Mueve la plataforma hacia adelante o hacia atr�s seg�n su posici�n
        if (distanciaRecorrida >= distancia)
        {
            moviendoHaciaPosicionInicial = !moviendoHaciaPosicionInicial;
        }

        // Determina la direcci�n de movimiento
        Vector3 direccionMovimiento = moviendoHaciaPosicionInicial ? -direccion : direccion;

        // Aplica el movimiento a la plataforma
        transform.Translate(direccionMovimiento * velocidad * Time.deltaTime);
    }
}
