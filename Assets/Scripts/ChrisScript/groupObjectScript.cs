using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groupObjectScript : DragAndDrop
{
    public GameObject[] group;
    // Start is called before the first frame update
    void Start()
    {
        group = new GameObject[transform.childCount];
        
        for (int i = 0; i< transform.childCount;i++)
        {
            group[i] = transform.GetChild(i).gameObject;
            group[i].GetComponent<ResizeScript>().enabled = false;
            group[i].GetComponent<DragAndDrop>().groupped = true;
            group[i].GetComponent<ResizeScript>().Enlarge();
        }
        StartCoroutine(CheckTesting());
        inToolBox = true;
    }
    private void Update()
    {
        inToolBox = false;
        foreach (GameObject g in group)
        {
            if (g.GetComponent<DragAndDrop>().inToolBox)
            {
                inToolBox = true;
            }
        }
        if (isGrabbing)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos + offset;
        }
        if (GetComponent<ResizeScript>() && !groupped)
        {
            if (!inToolBox)
            {
                GetComponent<ResizeScript>().Enlarge();
            }
            else
            {
                GetComponent<ResizeScript>().Shrink();
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && isGrabbing)
        {
            isGrabbing = false;
            if (inToolBox)
            {
                if (!GameObject.FindGameObjectWithTag("ToolBoxArea").GetComponent<Inventory>().Check(gameObject))
                {

                    GameObject.FindGameObjectWithTag("ToolBoxArea").GetComponent<Inventory>().Add(gameObject);
                }
            }
        }
    }

    public void GroupGrab()
    {
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
