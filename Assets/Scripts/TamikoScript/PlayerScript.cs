using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	private Rigidbody2D rb;
	private PlayButtonScript pbs;
	public float speed = 1;
	public float jumpForce = 50;

	public RacoonOnGroundScript rgs;
	public RacoonLadderScript rls;
	public SpriteRenderer sr;

	public bool canJump = true;
	public bool isClimbing = false;

	private bool facingRight;

	public Animator anim;

    public AudioClip jumpSound;


    private void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Start() {
		canJump = true;
		pbs = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>();
		pbs.onPlayButtonMethods += startStopRacoonUpdate; // add to the delegate thingy
	}

	void startStopRacoonUpdate() {
		/*if(pbs.gameTesting) { //start the racoon
			

			print("sop");
			StopCoroutine(updateRacoon());
			rb.velocity = Vector2.zero;
			rb.isKinematic = false;
			print(pbs.gameTesting);

		} else {//stop the racoon
			StartCoroutine(updateRacoon());
			print("sart");
			print(pbs.gameTesting);

		}*/
	}
	

	void Update() {

		if(pbs.gameTesting) {
			//print("fafdasad");
			rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

			if (Input.GetAxis("Horizontal") < -0.01f) {
				sr.flipX = false;
				anim.SetBool("IsWalking", true);
			} else if (Input.GetAxis("Horizontal") > 0.01f) {
				sr.flipX = true;
				anim.SetBool("IsWalking", true);
			} else {
				anim.SetBool("IsWalking", false);
			}

			if (rgs.onGround && canJump && (
				Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)
				|| Input.GetKeyDown(KeyCode.UpArrow))) {
				jump();
			}

			if (rls.touchingLadder) {

				if (Input.GetAxis("Vertical") != 0) {
					isClimbing = true;
				}

			} else {
				//stop climbing
				isClimbing = false;
			}

			if (isClimbing) {
                anim.SetBool("isClimbing", true);
				rb.isKinematic = true;
				rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * speed);
			} else {
				rb.isKinematic = false;
                anim.SetBool("isClimbing", false);
			}

		}

	}

	void jump() {
		rb.velocity = new Vector2(rb.velocity.x, 0);
		rb.AddForce(new Vector2(0, jumpForce));
        gameObject.GetComponent<AudioSource>().PlayOneShot(jumpSound);
		StartCoroutine(delayJump());
	}

	void climb() {

	}

	//slight delay before you can jump again
	IEnumerator delayJump() {
		canJump = false;
		yield return new WaitForSeconds(0.1f);
		canJump = true;
	}

	

}
