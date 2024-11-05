using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PLAYER : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI counttext;
    public GameObject win;
    [SerializeField] int jumpPower;

    
    
    private bool OnFloor = false;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        setCountText();

        win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Space) && OnFloor == true) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void setCountText()
    {
        counttext.text = "count :" + count.ToString();

        if (count >= 12)
        {
            win.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("enemy"));
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            // Destroy the current object
            Destroy(gameObject);
            // Update the winText to display "You Lose!"
            win.gameObject.SetActive(true);
            win.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
        

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickups"))
        {
            other.gameObject.SetActive(false);
            count++;

            setCountText ();
        }
        
    }

    void OnTriggerStay(Collider sphere)
    {
        if (sphere.gameObject.CompareTag("floor"))
        {
            OnFloor = true;
        }

    }

    void OnTriggerExit(Collider sphere)
    {
        if (sphere.gameObject.CompareTag("floor"))
        {
            OnFloor = false;
        }

    }


}
