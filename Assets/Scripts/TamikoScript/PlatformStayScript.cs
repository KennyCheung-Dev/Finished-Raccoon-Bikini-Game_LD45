using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStayScript : MonoBehaviour {

	public float force = 50;
	public HorizontalMovement rb;

	private void OnCollisionStay2D(Collision2D collision) {

		if(collision.gameObject.CompareTag("Player")) {
			Rigidbody2D p = collision.gameObject.GetComponent<Rigidbody2D>();
			//collision.gameObject.transform.parent = gameObject.transform;

			p.AddForce(new Vector2(rb.velocity * force , 0));
		//	print(p.velocity.x + " " + rb.velocity.x);
		}

		//print("huagh;");
	}

	private void OnCollisionExit2D(Collision2D collision) {
		//print("asda;");
		if (collision.gameObject.CompareTag("Player")) {
			//collision.gameObject.transform.parent = null;
		}
	}
}
