using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRefineScript : MonoBehaviour {

	public Collider2D[] extraCollider;
	public bool isInsideGroup;

    void Start() {
        
    }


	public void disableExtraColliders() {
		for (int i = 0; i < extraCollider.Length; i++) {
			extraCollider[i].enabled = false;
		}
	}
	
	public void enableExtraColliders() {
		for (int i = 0; i < extraCollider.Length; i++) {
			extraCollider[i].enabled = true;
		}
	}
}
