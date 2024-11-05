using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded; // Variable pública para saber si está tocando el suelo
    public Transform ball;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - ball.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = ball.position + offset;
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("floor"))
        {
            isGrounded = true;
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("floor"))
        {
            isGrounded = false;
        }
    }
}
