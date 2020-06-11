using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coloredObject : MonoBehaviour
{
    private PlayButtonScript pbs;
    private ConditionScript sceneCondition; 
    public enum ObjectColor { green, red, blue };
    public ObjectColor myColor;
    public bool inColorArea;
    public string corner1, corner2, corner3, corner4;

    public GameObject[] cornerChecks;

    private bool illegalItemAdded;
	public SpriteRenderer crossSprite;

	public bool grouped;

    // Start is called before the first frame update
    void Start()
    {
        pbs = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>();
        sceneCondition = GameObject.FindGameObjectWithTag("canvas").GetComponent<ConditionScript>();
        for (int i = 0; i < 4; i++)
        {
            cornerChecks[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            corner1 = cornerChecks[0].gameObject.GetComponent<tinyCornerCheck>().enteredColor.ToString();
            corner2 = cornerChecks[1].gameObject.GetComponent<tinyCornerCheck>().enteredColor.ToString();
            corner3 = cornerChecks[2].gameObject.GetComponent<tinyCornerCheck>().enteredColor.ToString();
            corner4 = cornerChecks[3].gameObject.GetComponent<tinyCornerCheck>().enteredColor.ToString();
        }

        //Keep Track of Colors
        if (myColor == ObjectColor.red)
        {
            if (corner1 == "red" && corner2 == "red" && corner3 == "red" && corner4 == "red")
            {
                inColorArea = true;
            }
            else
            {
                inColorArea = false;
            }
        }
        else if (myColor == ObjectColor.green)
        {
            if (corner1 == "green" && corner2 == "green" && corner3 == "green" && corner4 == "green")
            {
                inColorArea = true;
            }
            else
            {
                inColorArea = false;
            }
        }
        else if (myColor == ObjectColor.blue)
        {
            if (corner1 == "blue" && corner2 == "blue" && corner3 == "blue" && corner4 == "blue")
            {
                inColorArea = true;
            }
            else
            {
                inColorArea = false;
            }
        }


        //Enable and Disable Cross Child Sprite Renderer
		if(!grouped) {
			if (!gameObject.GetComponent<DragAndDrop>().inToolBox)
			{
				if (!pbs.gameTesting) { 
					if (!inColorArea)
					{
						if (!illegalItemAdded)
						{
							sceneCondition.changeIllegalItems(1);
							illegalItemAdded = true;
						}
						//crossSprite.enabled = true;
						gameObject.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().enabled = true;
					} else {
						if (illegalItemAdded)
						{
							sceneCondition.changeIllegalItems(-1);
							illegalItemAdded = false;
						}
						//crossSprite.enabled = false;
						gameObject.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().enabled = false;
					}
				}
			} else
			{
				if (illegalItemAdded)
				{
					sceneCondition.changeIllegalItems(-1);
					illegalItemAdded = false;
				}
				//crossSprite.enabled = false;
				gameObject.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().enabled = false;
			}
		} else {//grouped *ADDED BY TAMIKO

			if (!transform.parent.gameObject.GetComponent<DragAndDrop>().inToolBox) {
				if (!pbs.gameTesting) {
					if (!inColorArea) {
						if (!illegalItemAdded) {
							sceneCondition.changeIllegalItems(1);
							illegalItemAdded = true;
						}
						//crossSprite.enabled = true;
						gameObject.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().enabled = true;
					} else {
						if (illegalItemAdded) {
							sceneCondition.changeIllegalItems(-1);
							illegalItemAdded = false;
						}
						//crossSprite.enabled = false;
						gameObject.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().enabled = false;
					}
				}
			} else {
				if (illegalItemAdded) {
					sceneCondition.changeIllegalItems(-1);
					illegalItemAdded = false;
				}
				//crossSprite.enabled = false;
				gameObject.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().enabled = false;
			}
		}
    }
}
