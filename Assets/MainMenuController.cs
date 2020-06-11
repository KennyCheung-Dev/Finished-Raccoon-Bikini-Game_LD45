using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject[] screens;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePage(int n)
    {
        foreach (GameObject s in screens)
        {
            s.SetActive(false);
        }
        screens[n].SetActive(true);
    }
    public void LoadLevel(int n)
    {
        SceneManager.LoadScene(n);
    }
}
