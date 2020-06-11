using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacoonLadderScript : MonoBehaviour
{

	public bool touchingLadder;

	private void OnTriggerEnter2D(Collider2D col) {
		if(col.CompareTag("Ladder")) {
			touchingLadder = true;
		}
	}

	private void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag("Ladder")) {
			touchingLadder = false;
		}
	}

}
