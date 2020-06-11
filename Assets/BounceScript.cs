using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
	private PlayButtonScript pbs;
	public float bounciness = 10;


	private void Awake() {
		pbs = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>();
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<Rigidbody2D>() && pbs.gameTesting) { 
            Vector2 oldSpeed = collision.transform.GetComponent<Rigidbody2D>().velocity;
            collision.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(oldSpeed.x, bounciness);
        }
    }
}
