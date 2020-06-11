using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    private PlayButtonScript pbs;
    private bool moving;

    public float velocity = 1;
	private Rigidbody2D rb;
	public bool hadBeenHit;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
        pbs = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>();
        pbs.onPlayButtonMethods += toggleHorizontalMovement;
    }

    private void Update()
    {
        if (moving) {
			rb.velocity = new Vector2(velocity, 0);
			//print(rb.velocity);
            //gameObject.transform.position += new Vector3(velocity, 0, 0);
        }
    }

    void toggleHorizontalMovement()
    {
        if (!pbs.gameTesting)
        {
            moving = true;
        } else
        {
            moving = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "staticObject")
        {
			//print("SADasdsa");
			if(!hadBeenHit) {
				StartCoroutine(delayHit());
				velocity = -velocity;
			}
        }
    }

	//add slight delay to hit
	IEnumerator delayHit() {
		hadBeenHit = true;
		yield return new WaitForSeconds(0.3f);
		hadBeenHit = false;
	}
}
