using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 0;
    public int playerindex;
    public GroundCheck GroundCheck;
    [SerializeField] int jumpPower;



    private Transform respawnPoint;
    //private TextMeshProUGUI counttext;
    private MenuController MenuController;
    private TextMeshProUGUI LIVESTEXT;
    private GameObject win;
    
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {

        respawnPoint = GameObject.Find("respawn point").transform;
        MenuController = GameObject.Find("canvas").GetComponent< MenuController>();



        rb = GetComponent<Rigidbody>();
        count = 0;

        setCountText();

        win.SetActive(false);

        GroundCheck = transform.Find("GroundDetector").GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    private void Update()
    {


        if (Input.GetButtonDown("Jump") && GroundCheck.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (transform.position.y < -10)
        {
            lives = lives - 1;
            Respawn();
            setCountText();

        }

        if (count >= 12)
        {
            win.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("enemy"));
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
        //counttext.text = "count :" + count.ToString();
        LIVESTEXT.text = "lives :" + lives.ToString();

        
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickups"))
        {
            other.gameObject.SetActive(false);
            count++;

            setCountText();
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {

            lives = lives -1;
            Respawn();
            setCountText();
        }
        else if (lives <= 0)
        {
            // Destroy the current object
            Destroy(gameObject);
            // Update the winText to display "You Lose!"
            win.gameObject.SetActive(true);
            win.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }

    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }


}
