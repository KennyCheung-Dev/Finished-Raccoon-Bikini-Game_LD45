using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeScript : MonoBehaviour
{
    //public Vector3 smallSize;
    Vector3 largeSize, smallSize;
    public bool group;
    // Start is called before the first frame update
    void Start()
    {
        if (!group) {
			largeSize = transform.localScale;
			 float largest = transform.localScale.x;
			 if (transform.localScale.y > largest)
				 largest = transform.localScale.y;
			 smallSize = new Vector3(largeSize.x / largest, largeSize.y / largest, largeSize.z);
			 transform.localScale = smallSize;
			/*BoxCollider2D box = GetComponent<BoxCollider2D>();
			largeSize = Vector2.one;
			float largest = box.size.x;
			if (box.size.y > largest)
				largest = box.size.y;
			smallSize = new Vector2(1 / largest, 1 / largest);
			transform.localScale = smallSize;*/
		} else {
			largeSize = transform.localScale;
			float largest = transform.localScale.x;
			if (transform.localScale.y > largest)
				largest = transform.localScale.y;
			smallSize = largeSize;
			transform.localScale = smallSize;
			/*GameObject[] gr = GetComponent<groupObjectScript>().group;
            float leftMost = 0;
            float rightMost = 0;
            float topMost = 0;
            float bottomMost = 0;
            foreach (GameObject g in gr)
            {
                Transform t = g.transform;
                if (t.position.x - t.localScale.x/2 < leftMost)
                {
                    leftMost = t.position.x - t.localScale.x/2;
                }
                if (t.position.x + t.localScale.x/2 > rightMost)
                {
                    rightMost = t.position.x + t.localScale.x/2;
                }
                if (t.position.y - t.localScale.y/2 < bottomMost)
                {
                    bottomMost = t.position.y/2 - t.localScale.y;
                }
                if (t.position.y + t.localScale.y/2 > topMost)
                {
                    topMost = t.position.y + t.localScale.y/2;
                }
            }
            largeSize = transform.localScale;
            float largest = rightMost - leftMost;
            if (topMost - bottomMost > largest)
                largest = topMost - bottomMost;
            smallSize = new Vector3(largeSize.x / largest, largeSize.y / largest, largeSize.z);
            transform.localScale = smallSize;*/

		}
    }
	
    
    public void Enlarge()
    {
        transform.localScale = largeSize;
    }
    public void Shrink()
    {
        transform.localScale = smallSize;
    }
}
