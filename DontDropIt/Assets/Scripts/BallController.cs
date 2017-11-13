using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {
    public PlayerController player;
    public float jumpForwardMultiplier;
    public float ballJumpHeight;
    private Rigidbody2D rb;

    
    private bool touchingPlayer;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingPlayer = false;
        
        
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        
	}

    void FixedUpdate()
    {
        if (IsTouchingPlayer())
        {
            MoveWithPlayer();
        }

        if (Input.GetButtonDown("LaunchBall") && IsTouchingPlayer())
        {
            Debug.Log("Pressing Launch");
            float direction = Input.GetAxis("Horizontal");
            Jump(direction);
        }
    }

    public void Jump(float direction)
    {
        if (touchingPlayer)
        { 
            Vector2 forwardImpulse = new Vector2(jumpForwardMultiplier * direction, ballJumpHeight);
            rb.AddForce(forwardImpulse, ForceMode2D.Impulse);
        }
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            touchingPlayer = true;
        }    
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            touchingPlayer = false;    
        }       
    }

    void LaunchBall()
    {

    }

    bool IsTouchingPlayer()
    {
        return touchingPlayer;
    }

    void MoveWithPlayer()
    {
            Vector2 newPosition = new Vector2(player.transform.position.x, transform.position.y);
            rb.MovePosition(newPosition);

    }
}
