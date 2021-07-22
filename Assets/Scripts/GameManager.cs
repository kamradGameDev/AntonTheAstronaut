using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject menuSceneObj;
    public GameObject Items;
    public bool statusMenu = false;
    public bool startScene = false;
    public bool clickTvStatus = true;
    internal bool startClick;
    public bool soundOn;
    internal bool letsgoObj;
    public bool AllowSwipe = true;
    public float timeChangeSwipeStatus = 1.5f;
    public float maxTimeChangeSwipeStatus = 1.5f;
    public bool gameLevel = false;
    public bool letsGoClick = false;
    public GameObject menuCanvas;
    public Light2D globalLight;
    public bool clickSetting = false;
    public GameObject GlobalLightObj;
    public bool startChangleLevel = false;
    public float speedStatusTvLocalScale = 1f;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (timeChangeSwipeStatus > 0 && !AllowSwipe)
        {
            timeChangeSwipeStatus -= Time.fixedDeltaTime;
        }
        else
        {
            GameManager.instance.AllowSwipe = true;
            GameManager.instance.clickTvStatus = true;
            timeChangeSwipeStatus = maxTimeChangeSwipeStatus;
        }
    }
}
