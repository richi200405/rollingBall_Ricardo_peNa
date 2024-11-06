using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class initialspawn : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        var player1 = PlayerInput.Instantiate(prefab, 0, "WASD", 0, Keyboard.current);
        var player2 = PlayerInput.Instantiate(prefab, 1, "ARROWS", 1, Keyboard.current);

        player1.transform.position = new Vector3(-2, 0.5f, 0);
        player2.transform.position = new Vector3(2, 0.5f, 0);

        //player1.transform.parent;
    }

}   