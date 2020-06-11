using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    public bool canGrab, inToolBox;
    bool onTop;
    protected bool isGrabbing;
    public bool groupped;
	public bool rootGroup;
	public bool inGroup;
    public Vector3 offset;

    void Start()
    {
        StartCoroutine(CheckTesting());
        inToolBox = true;
    }
    // Update is called once per frame
        void Update()
    {
		if(!inGroup) {
			if (isGrabbing) { 
				Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				transform.position = pos + offset;
			}
			if (GetComponent<ResizeScript>()&& !groupped) { 
				if (!inToolBox)
				{
					GetComponent<ResizeScript>().Enlarge();
				} else
				{
					GetComponent<ResizeScript>().Shrink();
				}
			}

			//ADDED BY TAMIKO
			if(GetComponent<ResizeScript>() && rootGroup) {
				if (!inToolBox) {
					GetComponent<GrouperScript>().Enlarge();
				} else {
					GetComponent<GrouperScript>().Shrink();
				}
			}

			if (Input.GetKeyUp(KeyCode.Mouse0) && isGrabbing)
			{
				isGrabbing = false;
				if (inToolBox)
				{
					if (!GameObject.FindGameObjectWithTag("ToolBoxArea").GetComponent<Inventory>().Check(gameObject)) {

						GameObject.FindGameObjectWithTag("ToolBoxArea").GetComponent<Inventory>().Add(gameObject);
					}
				}
			}
		}

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ToolBoxArea")
        {
            inToolBox = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ToolBoxArea" && groupped && transform.parent.GetComponent<groupObjectScript>().isGrabbing)
        {
            inToolBox = false;
        }
        if (collision.tag == "ToolBoxArea" && isGrabbing)
        {
            inToolBox = false;
        }
    }
    void OnMouseOver()
    {
		if(!inGroup) {
			if (groupped)
			{
				transform.parent.GetComponent<groupObjectScript>().GroupGrab();
			} else { 
				if (Input.GetKeyDown(KeyCode.Mouse0) && canGrab)
				{
					isGrabbing = true;
					offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
					if (GameObject.FindGameObjectWithTag("ToolBoxArea").GetComponent<Inventory>().Check(gameObject))
					{

						GameObject.FindGameObjectWithTag("ToolBoxArea").GetComponent<Inventory>().Pull(gameObject);
					}
				}
			}
		}
    }
    protected IEnumerator CheckTesting()
    {
        while (true)
        {
            yield return new WaitUntil(() => GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>().gameTesting);
            canGrab &= inToolBox;
            yield return new WaitUntil(() => !GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>().gameTesting);
            canGrab = true;
        }
    }
}
