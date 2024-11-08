using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class initialspawn : MonoBehaviour
{
    public GameObject prefab;
    public Material player1Material;  // Material para el jugador 1
    public Material player2Material;  // Material para el jugador 2

    void Start()
    {
        var player1 = PlayerInput.Instantiate(prefab, 0, "WASD", 0, Keyboard.current);
        var player2 = PlayerInput.Instantiate(prefab, 1, "ARROWS", 1, Keyboard.current);

        player1.transform.position = new Vector3(-2, 0.5f, 0);
        player2.transform.position = new Vector3(2, 0.5f, 0);

        player1.transform.parent.GetChild(1).GetComponent<Camera>().rect = new Rect(0, 0, .5f, 1);
        player2.transform.parent.GetChild(1).GetComponent<Camera>().rect = new Rect(.5f, 0, .5f, 1);

        player1.transform.parent.GetChild(1).GetComponent<Camera>().GetComponent<AudioListener>().enabled = true;

        player1.GetComponent<PlayerController>().playerindex = 0;
        player2.GetComponent<PlayerController>().playerindex = 1;

        player2.name = "player2";

        player1.GetComponent<MeshRenderer>().material = player1Material;
        player2.GetComponent<MeshRenderer>().material = player2Material;


    }
}
