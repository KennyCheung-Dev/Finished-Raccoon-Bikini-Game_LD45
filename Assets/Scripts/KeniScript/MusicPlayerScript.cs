using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    
	#region SINGLETON PATTERN

    private static MusicPlayerScript _instance;
    public static MusicPlayerScript instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (MusicPlayerScript)FindObjectOfType(typeof(MusicPlayerScript));
                if (_instance == null)
                {
                    Debug.LogError("An instance of " + typeof(MusicPlayerScript) +
                        " is needed in the scene, but there is none.");
                }
            }

            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        if(_instance != null || GameObject.FindGameObjectsWithTag("music").Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }



}
