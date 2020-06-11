using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    private PlayButtonScript pbs;
    private bool moving;

    public float velocity = 1;

    // Start is called before the first frame update
    void Start()
    {
		pbs = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>();
		pbs.onPlayButtonMethods += toggleVerticalMovement;
	}

    private void Update()
    {
        if (moving)
        {
            gameObject.transform.position += new Vector3(0, velocity, 0);
        } 
    }

    void toggleVerticalMovement()
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
            velocity = -velocity;
        }
    }
}
