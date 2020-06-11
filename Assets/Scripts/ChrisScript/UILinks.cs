using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILinks : MonoBehaviour
{
    public Inventory toolbox;
    // Start is called before the first frame update
    void Start()
    {
        toolbox = GameObject.FindGameObjectWithTag("ToolBoxArea").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Forward()
    {
        toolbox.GoForward();
    }
    public void Backward()
    {
        toolbox.GoBackward();
    }
}
