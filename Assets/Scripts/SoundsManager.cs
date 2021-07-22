using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager instance;
    private MenuHelper menuHelper;
    public float timeTouch = 1f;
    public AudioSource[] audiosMusic;
    public AudioSource[] voiceSounds;
    public AudioSource[] musicGameLevels;
    public bool clickSoundPlayer;
    public int currentAudioPlay;
    public int currentNpCAudioPlay;
    public GameObject currentNPC;
    public int currentMenuAudio;
    private bool startGame = false;
    public GameObject LetsGoObj, nextAfterLetsGoObj;
    public AudioSource scenariousMusic;
    public bool OneScreen = true;
    private void Awake()
    {
        menuHelper = GameObject.FindObjectOfType<MenuHelper>();
        //GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
        if(!instance)
        {
            instance = this;
        }
        //if(objs.Length > 1)
        //{
        //    Destroy(this.gameObject);
        //}
        //else
        //{
        //    Debug.Log("DontDestroyOnLoad");
        //    DontDestroyOnLoad(this.gameObject);
        //}
        
    }
    private void Start()
    {
        if(!startGame)
        {
            //Debug.Log("test bg music");
            RandomStartMusic();
            RandomVoiceSoundInMenu();
            startGame = true;
        }
    }
    private void RandomVoiceSoundInMenu()
    {
        int random = Random.Range(0, voiceSounds.Length);
        currentMenuAudio = random;
        voiceSounds[random].Play();
        float time = voiceSounds[random].clip.length - 0.8f;
        Invoke("timeObjLetsGo", time);
    }
    private void timeObjLetsGo()
    {
        if(!GameManager.instance.letsGoClick)
        {
            LetsGoObj.SetActive(true);
            menuHelper.OnMouseDown();
        }
    }
    public void RandomMusicGameLevel()
    {
        currentAudioPlay = Random.Range(0, audiosMusic.Length);
        audiosMusic[currentAudioPlay].Play();
    }
    private void RandomStartMusic()
    {
        currentAudioPlay = Random.Range(0, audiosMusic.Length);
        audiosMusic[currentAudioPlay].Play();
    }
    
}
