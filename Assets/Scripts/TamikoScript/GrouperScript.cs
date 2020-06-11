using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrouperScript : MonoBehaviour
{

	/*
	#region SINGLETON PATTERN

    private static PlayerMovementScript _instance;
    public static PlayerMovementScript instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (PlayerMovementScript)FindObjectOfType(typeof(PlayerMovementScript));
                if (_instance == null)
                {
                    Debug.LogError("An instance of " + typeof(PlayerMovementScript) +
                        " is needed in the scene, but there is none.");
                }
            }

            return _instance;
        }
    }
    #endregion
	 * */

	private PlayButtonScript pbs;
	Vector2 largeSize, smallSize;
	// Start is called before the first frame update

	private void Awake() {
		//endTest();
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).GetComponent<coloredObject>().grouped = true;
		}
	}


	void Start() {
		pbs = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>();
		pbs.onPlayButtonMethods += callTest;
		resize();
		endTest();
    }

	//private void LateUpdate() {
	//resize();
	//}

	public void Enlarge() {
		transform.localScale = largeSize;
	}
	public void Shrink() {
		transform.localScale = smallSize;
	}

	public void resize() {
		BoxCollider2D box = GetComponent<BoxCollider2D>();
		largeSize = Vector2.one;
		float largest = box.size.x;
		if (box.size.y > largest)
			largest = box.size.y;
		smallSize = new Vector2(1 / largest, 1 / largest);
		transform.localScale = smallSize;
	}

	void callTest() {
		if(pbs.gameTesting) {
			endTest();
		} else {
			startTest();
		}
	}

    // Update is called once per frame
    private void startTest() {
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
			transform.GetChild(i).GetComponent<DragAndDrop>().enabled = true;
			if (transform.GetChild(i).GetComponent<SelectRefineScript>()) {
				transform.GetChild(i).GetComponent<SelectRefineScript>().enableExtraColliders();
			}
		}
	}

	private void endTest() {
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
			transform.GetChild(i).GetComponent<DragAndDrop>().inGroup = true;
			transform.GetChild(i).GetComponent<DragAndDrop>().enabled = false;
			if(transform.GetChild(i).GetComponent<ResizeScript>()) {
				transform.GetChild(i).GetComponent<ResizeScript>().group = true;
			}
			if (transform.GetChild(i).GetComponent<SelectRefineScript>()) {
				transform.GetChild(i).GetComponent<SelectRefineScript>().disableExtraColliders();
			}
		}
	}
}
