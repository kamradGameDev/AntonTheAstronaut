using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevels : MonoBehaviour
{
    private ControlChapter controlChapter;
    //private MenuHelper menuHelper;
    PointsHelper pointsHelper;
    public GameObject[] BgImg;
    public GameObject[] settingsByttonState;
    //public GameObject[] headLineState;
    public GameObject tv_1;
    public GameObject anotherTv;
    private Animator anotherTvAnimator;
    //public bool startChangleLevel = false;
    public bool ChangeImg = false;
    //private bool timeBGStart;
    public GameObject BGDark;
    private bool oneClick = false;
    public AudioSource audioClip;
    [SerializeField] private bool letsgoObj;
    private void Start()
    {
        controlChapter = GameObject.FindObjectOfType<ControlChapter>();
        pointsHelper = GameObject.FindObjectOfType<PointsHelper>();
        anotherTvAnimator = anotherTv.GetComponent<Animator>();
    }
    public void OnMouseUp()
    {
        if(!GameManager.instance.clickSetting && GameManager.instance.clickTvStatus && (ControlChapter.instance.swipeStatus == SwipeStatus.endSwipe || ControlChapter.instance.swipeStatus == SwipeStatus.noSwipe))
        {
            ControlChapter.instance.time = 0;
            GameManager.instance.clickTvStatus = false;
            GameManager.instance.AllowSwipe = false;
            GameManager.instance.timeChangeSwipeStatus = GameManager.instance.maxTimeChangeSwipeStatus;
            
            if (!GameManager.instance.startChangleLevel && !oneClick)
            {
                SoundsManager.instance.voiceSounds[SoundsManager.instance.currentMenuAudio].Stop();
                SoundsManager.instance.OneScreen = false;
                //oneClick = true;
                GameManager.instance.letsGoClick = true;
                if (audioClip && !GameManager.instance.letsgoObj)
                {
                    SoundsManager.instance.LetsGoObj.SetActive(true);
                    GameManager.instance.letsgoObj = true;
                    audioClip.Play();
                    Invoke("TimeScreenAdventures", audioClip.clip.length);
                }
            }
            else if(GameManager.instance.startChangleLevel && this.GetComponent<StatusTV>().status)
            {
                Invoke("timeNextTv", 0.5f);
                //GameManager.instance.swipeStatus = false;
                //Invoke("timeChangeStatus", 1.5f);
                //Debug.Log("test");
                //Debug.Log("test_1");
                MenuManager.instance.tv_screens[0].transform.GetChild(0).GetComponent<Animator>().enabled = true;
                MenuManager.instance.tv_screens[0].transform.GetChild(1).GetComponent<Animator>().enabled = true;
                MenuManager.instance.headLineState[1].GetComponent<Animator>().SetTrigger("Close");

                MenuManager.instance.tv_screens[0].transform.GetChild(0).GetComponent<Animator>().SetTrigger("Close");
                MenuManager.instance.tv_screens[0].transform.GetChild(1).GetComponent<Animator>().SetTrigger("Close");
                MenuManager.instance.backButton.GetComponent<Animator>().SetTrigger("Open");
                MenuManager.instance.levelLoadingPermission = true;

                MenuManager.instance.tv_screens[1].SetActive(true);
                SoundsManager.instance.audiosMusic[SoundsManager.instance.currentAudioPlay].Pause();
                SoundsManager.instance.scenariousMusic.Play();
                MenuManager.instance.tv_screens[1].transform.GetChild(0).GetComponent<Animator>().SetTrigger("Open");
                MenuManager.instance.tv_screens[1].transform.GetChild(1).GetComponent<Animator>().SetTrigger("Open");
                oneClick = false;

                
                pointsHelper.StartPoints(4);
                pointsHelper.activeCount = 0;
                //controlChapter.speedSwipe = 200;
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        pointsHelper.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = controlChapter.pointsState[1];
                    }
                    else
                    {
                        pointsHelper.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = controlChapter.pointsState[0];
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        controlChapter.TvObjs[i].transform.position = new Vector3(0, 0, 0);
                        controlChapter.target[i] = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        //Debug.Log("test points");
                        controlChapter.TvObjs[i].transform.position = new Vector3(6, 0, 0);
                        controlChapter.target[i] = new Vector3(6, 0, 0);
                    }
                }
                if (MenuManager.instance.backButtonAnim.GetCurrentAnimatorStateInfo(0).IsName("Default") || MenuManager.instance.backButtonAnim.GetCurrentAnimatorStateInfo(0).IsName("Close") || MenuManager.instance.backButtonAnim.GetCurrentAnimatorStateInfo(0).IsName("Open"))
                {
                    MenuManager.instance.backButtonAnim.SetTrigger("Open");
                }
                //controlChapter.speedSwipe = 20;
            }
                
            //}
        }
    }
    private  void TimeScreenAdventures()
    {
        settingsByttonState[0].SetActive(false);
        settingsByttonState[1].SetActive(true);
        if (!GameManager.instance.startChangleLevel)
        {
            MenuManager.instance.BgDark.gameObject.SetActive(false);
            MenuManager.instance.headLineState[0].GetComponent<Animator>().SetTrigger("Close_1");
            MenuManager.instance.headLineState[1].GetComponent<Animator>().SetTrigger("Open");
            anotherTvAnimator.SetTrigger("Open");
            Invoke("change", 0.3f);
            pointsHelper.StartPoints(2);
            MenuManager.instance.bgScreens[0].SetActive(false);
            MenuManager.instance.bgScreens[1].SetActive(true);
            GameManager.instance.Items.SetActive(false);
            if (SoundsManager.instance.LetsGoObj.activeSelf)
            {
                SoundsManager.instance.LetsGoObj.SetActive(false);
                SoundsManager.instance.nextAfterLetsGoObj.SetActive(true);
            }
            
            SoundsManager.instance.OneScreen = true;
        }
        this.transform.localScale = new Vector3(0.9186f, 0.948f, 1);
        tv_1.SetActive(true);
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);
        if (BGDark)
        {
            BGDark.SetActive(true);
        }
    }
    //private void timeChangeStatus()
    //{
    //    GameManager.instance.swipeStatus = true;
    //    GameManager.instance.AllowSwipe = true;
    //}
    //public void BackChangeLevels()
    //{
    //    if(MenuManager.instance.tv_screens[0].activeSelf)
    //    {
    //        MenuManager.instance.tv_screens[0].GetComponent<Animator>().SetTrigger("Close");
            
    //    }
    //    if(MenuManager.instance.tv_screens[1].activeSelf)
    //    {
    //        MenuManager.instance.tv_screens[1].transform.GetChild(0).GetComponent<Animator>().SetTrigger("Close");
    //        MenuManager.instance.tv_screens[1].transform.GetChild(1).GetComponent<Animator>().SetTrigger("Close");
    //    }
    //    //Invoke("timeAnim", 1f);
        
    //}
    private void timeNextTv()
    {
        MenuManager.instance.tv_screens[0].SetActive(false);
    }
    //public void TimeBG()
    //{
    //    timeBGStart = true;
    //}
    private void change()
    {
        GameManager.instance.startChangleLevel = true;
    }
}
