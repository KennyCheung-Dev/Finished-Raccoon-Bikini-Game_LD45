using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayButtonScript : MonoBehaviour {

	public delegate void onPlayButton();

	public onPlayButton onPlayButtonMethods;

    public bool gameTesting;

    private ConditionScript sceneCondition;

    private AudioSource myAudio;

    public AudioClip cancelSound;

    public void Start()
    {
        sceneCondition = GameObject.FindGameObjectWithTag("canvas").GetComponent<ConditionScript>();
        myAudio = gameObject.GetComponent<AudioSource>();
    }
    //Check ReactToPlayButton for added methods
    public void startTesting() {
        if (sceneCondition.illegalItems == 0)
        {
            onPlayButtonMethods?.Invoke();
            if (gameTesting)
            {
                gameTesting = false;
            }
            else
            {
                gameTesting = true;
            }
        } else
        {
            myAudio.PlayOneShot(cancelSound);
        }
	}
}
