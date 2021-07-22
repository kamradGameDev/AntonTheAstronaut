using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelBGMusic : MonoBehaviour
{
    public static GameLevelBGMusic instance;
    //public AudioSource bgMusic;
    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }
    private void Start()
    {
        //SoundsManager.instance.scenariousMusic.gameObject.SetActive(true);
        SoundsManager.instance.scenariousMusic.Play();
        //bgMusic.Play();
    }
}
