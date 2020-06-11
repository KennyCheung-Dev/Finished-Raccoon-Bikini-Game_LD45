using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactToPlayButton : MonoBehaviour {
	
	private Rigidbody2D rb;
	private PlayButtonScript pbs;
	public bool hasGravity;
	public bool isPlatform;
	public bool isX;

	private bool gamePlaying;

    private Vector3 originalPosition = new Vector3(0, 0, 0);
    private float originalVelocity;
    private float originalGravityScale;

	private void Awake()
    {
            rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
		pbs = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>();
		//rb.gravityScale = 0;
		rb.isKinematic = true;

        //Kenny butchered these line
        pbs.onPlayButtonMethods += saveOriginalValues;
        pbs.onPlayButtonMethods += startAndStop;
    }

    //Kenny butchered these line
    void startAndStop()
    {
        gamePlaying = !pbs.gameTesting;

        if (hasGravity) 
        {
            if (gamePlaying)
            {
                turnOnWithGravity();
            } else
            {
                turnOffWithGravity();
            }
        } else
        {
            if (gamePlaying)
            {
                turnOnWithoutGravity();
            } else
            {
                turnOffWithoutGravity();
            }
        }
    }

	//freezes the position for static items (double check if this works)
	void turnOnWithoutGravity() {
		if(isPlatform) {
			if(isX) {
				rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
			} else {
				rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			}
		} else {
			rb.constraints = RigidbodyConstraints2D.FreezePositionX |
				RigidbodyConstraints2D.FreezePositionY |
				RigidbodyConstraints2D.FreezeRotation;
		}
        rb.isKinematic = false;
    }

    void turnOffWithoutGravity() {
        gameObject.transform.position = originalPosition;
		rb.velocity = Vector2.zero;
		rb.isKinematic = true;
		rb.constraints = RigidbodyConstraints2D.None |
		   RigidbodyConstraints2D.None |
		   RigidbodyConstraints2D.FreezeRotation;
        if (GetComponent<VerticalMovement>())
        {
            GetComponent<VerticalMovement>().velocity = originalVelocity;
        }
        if (GetComponent<HorizontalMovement>())
        {
            GetComponent<HorizontalMovement>().velocity = originalVelocity;
        }
        if (GetComponent<FallWhenStep>())
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void turnOnWithGravity() {
		//rb.gravityScale = 1;
		rb.isKinematic = false;
	}

    void turnOffWithGravity()
    {
		gameObject.transform.position = originalPosition;
		rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        if (GetComponent<FallWhenStep>())
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }

    }

        //Kenny Destroyed stuff here
        void saveOriginalValues()
    {
        if (!gamePlaying)
        {
            originalPosition = gameObject.transform.position;
            if (GetComponent<VerticalMovement>())
            {
                originalVelocity = GetComponent<VerticalMovement>().velocity;
            }
            if (GetComponent<HorizontalMovement>())
            {
                originalVelocity = GetComponent<HorizontalMovement>().velocity;
            }
        }
    }

    //resets thing to original state
    void resetPlay() {

	}
}
