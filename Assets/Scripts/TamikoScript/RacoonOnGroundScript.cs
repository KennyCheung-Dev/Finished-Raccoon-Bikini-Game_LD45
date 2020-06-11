using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacoonOnGroundScript : MonoBehaviour {

	public bool onGround;
	public Animator anim;
	

	private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.GetComponent<GroundScript>() != null)
        {
            onGround = true;
            anim.SetBool("OnAir", false);
        }
	}

	private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.GetComponent<GroundScript>() != null)
        {
            onGround = false;
            anim.SetBool("OnAir", true);
        }
	}
}
