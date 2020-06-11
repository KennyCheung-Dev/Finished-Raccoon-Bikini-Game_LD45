using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bikiniScript : MonoBehaviour
{
    public bool activated;
    bool testing;
    public AudioClip coinSound;
    void Start()
    {
        //StartCoroutine(CheckTesting());
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>().gameTesting)
        {
            testing = true;
        }
        else
        {
            testing = false;
            activated = false;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && testing)
        {
            activated = true;
            gameObject.GetComponent<AudioSource>().PlayOneShot(coinSound);
            transform.parent.position = new Vector2(1000, 1000);
        }

    }

    //IEnumerator CheckTesting()
    //{
    //    while (true)
    //    {
    //        yield return new WaitUntil(() => GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>().gameTesting);
    //        testing = true;
    //        yield return new WaitUntil(() => !GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>().gameTesting);
    //        testing = false;
    //        activated = false;
    //    }
    //}

}
