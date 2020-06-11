using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConditionScript : MonoBehaviour
{
    public int bikinis;
    public int remaining;
    public GameObject[] all;
    public GameObject WinScreen;
    public int illegalItems;

    // Start is called before the first frame update
    void Start()
    {   
        all = GameObject.FindGameObjectsWithTag("goal");
        bikinis = all.Length;

    }
    private void Update()
    {
        int count = 0;
        foreach (GameObject b in all)
        {
            if (!b.GetComponentInChildren<bikiniScript>().activated)
            {
                count++;
            }
        }
        remaining = count;
        if (count <= 0)
        {
            WinScreen.SetActive(true);
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMenu()
    {
        //0 = Menu
        SceneManager.LoadScene(0);
    }
    public void changeIllegalItems(int i)
    {
        illegalItems += i;
    }
}
