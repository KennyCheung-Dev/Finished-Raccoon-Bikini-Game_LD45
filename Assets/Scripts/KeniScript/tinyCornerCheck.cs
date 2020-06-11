using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tinyCornerCheck : MonoBehaviour
{
    public enum ObjectColor { red, green, blue, none };
    public ObjectColor enteredColor = ObjectColor.none;

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "redArea":
                enteredColor = ObjectColor.red;
                break;
            case "greenArea":
                enteredColor = ObjectColor.green;
                break;
            case "blueArea":
                enteredColor = ObjectColor.blue;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "redArea" || collision.gameObject.tag == "greenArea" || collision.gameObject.tag == "blueArea")
             enteredColor = ObjectColor.none;
    }
}
