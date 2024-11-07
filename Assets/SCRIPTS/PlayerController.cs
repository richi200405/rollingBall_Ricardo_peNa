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
    private MenuController menuController;
    private ScoreHandeler scoreHandeler;
    private TextMeshProUGUI LIVESTEXT;
    private GameObject win;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    private int lives = 3;

    void Start()
    {
        respawnPoint = GameObject.Find("respawn_point").transform;
        menuController = GameObject.Find("Canvas").GetComponent<MenuController>();
        scoreHandeler = GameObject.Find("Canvas/counts").GetComponent<ScoreHandeler>();

        rb = GetComponent<Rigidbody>();
        count = 0;

        setCountText();

        win.SetActive(false);

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
            win.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("enemy"));
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
            scoreHandeler.Score += 1;

            setCountText();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            lives -= 1;
            Respawn();
            setCountText();
        }
        else if (lives <= 0)
        {
            Destroy(gameObject);
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
