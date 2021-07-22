using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    private ControlChapter controlChapter;
    public GameObject backButton;
    public Animator backButtonAnim;
    public GameObject[] tv_screens = new GameObject[2];
    private PointsHelper pointsHelper;
    public GameObject[] headLineState;
    private Animator[] healineAnimator = new Animator[2];
    public GameObject[] buttons;
    public GameObject[] bgScreens;
    public bool levelLoadingPermission = false;
    private Animator[] tv_screensNull = new Animator[2];
    private Animator[] tvScreenOne = new Animator[2];
    public SpriteRenderer BgDark;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        controlChapter = GameObject.FindObjectOfType<ControlChapter>();
        pointsHelper = GameObject.FindObjectOfType<PointsHelper>();
        tv_screens = GameObject.FindGameObjectsWithTag("TV");
        tv_screens[1].SetActive(false);
    }
    private void Start()
    {
        tv_screensNull[0] = tv_screens[0].transform.GetChild(0).GetComponent<Animator>();
        tv_screensNull[1] = tv_screens[0].transform.GetChild(1).GetComponent<Animator>();
        tvScreenOne[0] = tv_screens[1].transform.GetChild(0).GetComponent<Animator>();
        tvScreenOne[1] = tv_screens[1].transform.GetChild(1).GetComponent<Animator>();
        healineAnimator[0] = headLineState[0].GetComponent<Animator>();
        healineAnimator[1] = headLineState[1].GetComponent<Animator>();
        backButtonAnim = backButton.GetComponent<Animator>();
    }
    public void BackChangeLevels()
    {
        if(GameManager.instance.clickTvStatus)
        {
            GameManager.instance.GlobalLightObj.SetActive(true);
            Invoke("timeAnim", 0.5f);
            tvScreenOne[0].enabled = true;
            tvScreenOne[1].enabled = true;
            tvScreenOne[0].SetTrigger("Close");
            tvScreenOne[1].SetTrigger("Close");
            tv_screens[0].SetActive(true);
            tv_screensNull[0].SetTrigger("Open");
            tv_screensNull[1].SetTrigger("Open");
            MenuManager.instance.levelLoadingPermission = false;
            pointsHelper.activeCount = 0;
            pointsHelper.StartPoints(2);
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    pointsHelper.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = controlChapter.pointsState[1];
                    controlChapter.target[i] = new Vector3(0, 0, 0);
                }
                else
                {
                    pointsHelper.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = controlChapter.pointsState[0];
                    controlChapter.target[i] = new Vector3(6, 0, 0);
                }
            }
            GameManager.instance.clickTvStatus = false;
            backButtonAnim.SetTrigger("Close");

            

            SoundsManager.instance.scenariousMusic.Pause();
            SoundsManager.instance.audiosMusic[SoundsManager.instance.currentAudioPlay].Play();
            GameManager.instance.AllowSwipe = false;
            GameManager.instance.timeChangeSwipeStatus = GameManager.instance.maxTimeChangeSwipeStatus;
            if (healineAnimator[1].GetCurrentAnimatorStateInfo(0).IsName("Close"))
            {
                healineAnimator[1].SetTrigger("Open");
            }
            else
            {
                healineAnimator[1].SetTrigger("Open");
            }
        }
    }
    public void BackToHome()
    {
        GameManager.instance.letsgoObj = false;
        BgDark.gameObject.SetActive(true);
        if (backButtonAnim.GetCurrentAnimatorStateInfo(0).IsName("Open") || backButtonAnim.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            backButtonAnim.SetTrigger("Close");
        }
        GameManager.instance.GlobalLightObj.SetActive(true);
        MenuManager.instance.levelLoadingPermission = false;
        GameManager.instance.startChangleLevel = false;
        buttons[1].SetActive(false);
        buttons[0].SetActive(true);
        pointsHelper.activeCount = 0;
        pointsHelper.StartPoints(0);
        
        headLineState[0].GetComponent<Animator>().SetTrigger("Open_1");
        if (healineAnimator[1].GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            healineAnimator[1].SetTrigger("Close");
        }
            
        for (int i = 0; i < pointsHelper.pointsObj.Length; i++)
        {
            if(i == 0)
            {
                pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite = ControlChapter.instance.pointsState[1];
            }
            else
            {
                pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite = ControlChapter.instance.pointsState[0];
            }
        }
        
        if (tv_screens[0].activeSelf)
        {
            tv_screens[0].transform.GetChild(0).GetComponent<Animator>().enabled = true;
            tv_screens[0].transform.GetChild(1).GetComponent<Animator>().enabled = true;
            tv_screensNull[0].SetTrigger("Close");
            tv_screensNull[1].SetTrigger("Close");
            tv_screensNull[0].SetTrigger("Open");
        }
        else
        {
            tvScreenOne[0].enabled = true;
            tvScreenOne[1].enabled = true;
            if(tvScreenOne[0].GetCurrentAnimatorStateInfo(0).IsName("Default") || tvScreenOne[0].GetCurrentAnimatorStateInfo(0).IsName("Open"))
            {
                tvScreenOne[0].SetTrigger("Close");
                tvScreenOne[1].SetTrigger("Close");
            }
            tv_screens[0].SetActive(true);
            tv_screensNull[0].enabled = true;
            tv_screensNull[1].enabled = true;
            tv_screensNull[1].SetTrigger("Close");
            tv_screensNull[0].SetTrigger("Open"); 
        }
        SoundsManager.instance.LetsGoObj.SetActive(true);
        SoundsManager.instance.nextAfterLetsGoObj.SetActive(false);
        GameManager.instance.Items.SetActive(true);
        GameManager.instance.startChangleLevel = false;
        
        Invoke("timePassiveObjectAnim", 1f);
        
        if (tv_screens[1].activeSelf)
        {
            SoundsManager.instance.scenariousMusic.Pause();
            SoundsManager.instance.audiosMusic[SoundsManager.instance.currentAudioPlay].Play();
        }
        MenuManager.instance.bgScreens[0].SetActive(true);
        MenuManager.instance.bgScreens[1].SetActive(false);
    }
    private void timePassiveObjectAnim()
    {
        if(tv_screens[0].activeSelf)
        {
            tv_screens[0].SetActive(true);
            tv_screens[1].SetActive(false);
        }
        else
        {
            tv_screens[0].SetActive(false);
            tv_screens[1].SetActive(true);
        }
    }
    private void timeAnim()
    {
        tv_screens[1].SetActive(false);
        Debug.Log("test back button");
        GameManager.instance.clickTvStatus = true;
    }
}
