using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public AudioManager audioManager;
    
    public float moveSpeed;
    public float jumpHeight;
    public Text scoreText;
    Rigidbody2D rb;
    bool isGrounded;
    bool canDoubleJump;
    int playerScore;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        canDoubleJump = false;
        isGrounded = false;
        playerScore = 0;
        scoreText.text = "Score: 0 ";

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Jump")) { PlayerJump(); }
        MovePlayerHorizontally();
        RotatePlayer();

        if (Input.GetButtonDown("LaunchBall")) { Debug.Log("Test");}
    }

    void MovePlayerHorizontally()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 currentVelocity = rb.velocity;
        Vector2 movement = new Vector2(moveHorizontal*moveSpeed, currentVelocity.y);
        rb.velocity = movement;

    }

    void PlayerJump()
    {
        if (isGrounded)
        {
            Debug.Log("Player Jump");
            Vector2 jumpVector = new Vector2(0, jumpHeight);
            rb.AddForce(jumpVector,ForceMode2D.Impulse);
            canDoubleJump = true;
        }
        else
        {
            if (canDoubleJump)
            {
                canDoubleJump = false;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
        else if(coll.gameObject.tag == "Coin")
        {
            coll.gameObject.SetActive(false);
            
            SetScore();
            Debug.Log("Touching Coin");
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Test");
        Destroy(coll.gameObject);
        SetScore();
    }


    
    public bool IsJumping()
    {
        return (rb.velocity.y > 0.05);
    }

    void RotatePlayer()
    {
        float rotation = Input.GetAxis("HorizontalRotation");
        rb.rotation += (rotation * 2f);
    }

    void SetScore()
    {
        playerScore++;
        scoreText.text = "Score: " + playerScore;
        audioManager.PlayCoinSound();
    }
}
