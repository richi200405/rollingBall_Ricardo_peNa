using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlataformaMovil : MonoBehaviour
{
    // Variables públicas para ajustar desde el Inspector
    public Vector3 direccion = Vector3.right; // Dirección de movimiento (ej: derecha)
    public float velocidad = 2f; // Velocidad de movimiento
    public float distancia = 5f; // Distancia total que recorrerá

    // Variables privadas para el seguimiento de la posición inicial
    private Vector3 posicionInicial;
    private bool moviendoHaciaPosicionInicial = false;

    private void Start()
    {
        // Guarda la posición inicial de la plataforma
        posicionInicial = transform.position;
    }

    private void Update()
    {
        // Determina la distancia recorrida desde la posición inicial
        float distanciaRecorrida = Vector3.Distance(posicionInicial, transform.position);

        // Mueve la plataforma hacia adelante o hacia atrás según su posición
        if (distanciaRecorrida >= distancia)
        {
            moviendoHaciaPosicionInicial = !moviendoHaciaPosicionInicial;
        }

        // Determina la dirección de movimiento
        Vector3 direccionMovimiento = moviendoHaciaPosicionInicial ? -direccion : direccion;

        // Aplica el movimiento a la plataforma
        transform.Translate(direccionMovimiento * velocidad * Time.deltaTime);
    }
}
