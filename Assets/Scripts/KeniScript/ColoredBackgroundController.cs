using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredBackgroundController : MonoBehaviour
{
    public SpriteRenderer coloredBackground;
    private PlayButtonScript pbs;
    private bool determinedState;

    // Start is called before the first frame update
    void Start()
    {
        pbs = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>();

        coloredBackground = gameObject.transform.Find("coloredBackground").gameObject.GetComponent<SpriteRenderer>();

        if (GetComponent<coloredObject>().enabled == false)
        {
            coloredBackground.enabled = false;
        }
        else
        {
            if (GetComponent<coloredObject>().myColor == coloredObject.ObjectColor.red)
            {
                coloredBackground.color = new Color(0.98f, 0.88f, 0.88f, 1.0f);
            }
            else if (GetComponent<coloredObject>().myColor == coloredObject.ObjectColor.green)
            {
                coloredBackground.color = new Color(0.89f, 1.0f, 0.9f, 1.0f);
            }
            else if (GetComponent<coloredObject>().myColor == coloredObject.ObjectColor.blue)
            {
                coloredBackground.color = new Color(0.98f, 0.965f, 0.765f, 1.0f);
            }
        }

        if (coloredBackground.enabled == true)
        {
            determinedState = true;
        } else
        {
            determinedState = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pbs.gameTesting)
        {
            coloredBackground.enabled = determinedState;
        }
        else
        {
            coloredBackground.enabled = false;
        }
    }

    public void turnOffColoredBackground()
    {
        coloredBackground.enabled = false;
    }

    public void turnOnColoredBackground()
    {
        coloredBackground.enabled = true;
    }
}
