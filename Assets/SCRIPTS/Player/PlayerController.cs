using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    //public
    public float speed = 0;
    public int playerindex;
    public GroundCheck GroundCheck;
    [SerializeField] int jumpPower;


    //private
    private Transform respawnPoint;
    private MenuController menuController;
    private ScoreHandeler scoreHandeler;
    private liveshandeler liveshandeler;

    private AudioSource pop;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    private int lives = 3;

    void Start()
    {
        Time.timeScale = 1;

        respawnPoint = GameObject.Find("respawn_point").transform;
        menuController = GameObject.Find("Canvas").GetComponent<MenuController>();
        scoreHandeler = GameObject.Find("Canvas/counts").GetComponent<ScoreHandeler>();
        liveshandeler = GameObject.Find("Canvas/live").GetComponent<liveshandeler>();
        pop = GetComponent<AudioSource>(); 


        rb = GetComponent<Rigidbody>();
        count = 0;

        setCountText();

        

        GroundCheck = transform.Find("GroundDetector").GetComponent<GroundCheck>();
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            lives -= 1;
            Respawn();
            setCountText();
        }

        if (scoreHandeler.Score >= 12)
        {
            
            menuController.WinGame();
            Destroy(GameObject.FindGameObjectWithTag("enemy"));
            Time.timeScale = 0;
        }

        else if (lives <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("enemy"));
            Destroy(gameObject);
            EndGame();
            Time.timeScale = 0;

        }
    }

    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    public void OnJump()
    {
        if (GroundCheck.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    void setCountText()
    {
        menuController.addCounttext(playerindex, count);
        menuController.addlivestext(playerindex, lives);
        
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
            scoreHandeler.Score += 1;
            pop.Play();


            setCountText();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            lives -= 1;
            liveshandeler.live -= 1;
            Respawn();
            setCountText();
        }

        if (collision.gameObject.CompareTag("enemyterrain"))
        {
            lives -= 1;
            liveshandeler.live -= 1;
            Respawn();
            setCountText();
        }


    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }

    void EndGame() 
    {
        menuController.LoseGame();
        
       
    }

   
}
