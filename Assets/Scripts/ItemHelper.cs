using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHelper : MonoBehaviour
{
    public GameObject BennyEffect;
    public GameObject BennySpeechBubble;
    public bool MoonObj = false;
    public bool bubblesObj = false;
    public AudioSource clickAudio;
    private SpriteRenderer material;
    public float changeOutline = 0.1f;
    public Color OutlineColor_0, OutlineColor_1;
    private MaterialManager materialManager;
    private SmartRobotHelper smartRobotHelper;
    public Color color_0 = Color.red;
    public Color color_1 = Color.blue;
    private void Start()
    {
        //if(bubblesObj)
        //{
        //    clickAudio = GameObject.Find("BubbleSound").GetComponent<AudioSource>();
        //}
        OutlineColor_0 = color_0;
        OutlineColor_1 = color_1;
        changeOutline = 1;
        material = this.GetComponent<SpriteRenderer>();
        materialManager = GameObject.FindObjectOfType<MaterialManager>();
        smartRobotHelper = this.GetComponent<SmartRobotHelper>();
    }
    private void OnMouseDown()
    {
        if(bubblesObj)
        {
            if (!SoundsManager.instance.clickSoundPlayer)
            {
                if (SoundsManager.instance.currentNPC)
                {
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().sounds[SoundsManager.instance.currentNpCAudioPlay].Stop();
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleClick = false;
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.SetActive(false);
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().GlowEffect.SetActive(false);
                    SoundsManager.instance.currentNPC.GetComponent<SpriteRenderer>().material = materialManager.itemOutlineMaterials[0];
                }
                SoundsManager.instance.clickSoundPlayer = true;
                materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor", OutlineColor_0);
                materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor2", OutlineColor_1);
                materialManager.itemOutlineMaterials[1].SetFloat("_OutlineThickness", changeOutline);
                BubbleSound.instance.sound.Play();
                material.material = materialManager.itemOutlineMaterials[1];
                if (this.GetComponent<ItemRotate>())
                {
                    this.GetComponent<ItemRotate>().click = true;
                }
                float time = BubbleSound.instance.sound.clip.length;
                if (this.GetComponent<Animator>())
                {
                    this.GetComponent<Animator>().SetTrigger("Move");
                }
                Invoke("time", time);
                //if(smartRobotHelper)
                //{
                //    smartRobotHelper.click = true;
                //    smartRobotHelper.Click();
                //}
            }
        }
        if(MoonObj)
        {
            if (!SoundsManager.instance.clickSoundPlayer)
            {
                if (SoundsManager.instance.currentNPC)
                {
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().sounds[SoundsManager.instance.currentNpCAudioPlay].Stop();
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleClick = false;
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.SetActive(false);
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().GlowEffect.SetActive(false);
                    SoundsManager.instance.currentNPC.GetComponent<SpriteRenderer>().material = materialManager.itemOutlineMaterials[0];
                }
                BennyEffect.SetActive(true);
                BennySpeechBubble.SetActive(true);
                SoundsManager.instance.clickSoundPlayer = true;
                BennySpeechBubble.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                BennySpeechBubble.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor", OutlineColor_0);
                materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor2", OutlineColor_1);
                materialManager.itemOutlineMaterials[1].SetFloat("_OutlineThickness", changeOutline);
                clickAudio.Play();
                material.material = materialManager.itemOutlineMaterials[1];
                if (this.GetComponent<ItemRotate>())
                {
                    this.GetComponent<ItemRotate>().click = true;
                }
                float time = clickAudio.clip.length;
                if (this.GetComponent<Animator>())
                {
                    this.GetComponent<Animator>().SetTrigger("Move");
                }
                Invoke("time", time);
                //if(smartRobotHelper)
                //{
                //    smartRobotHelper.click = true;
                //    smartRobotHelper.Click();
                //}
            }
        }
        else
        {
            if (!SoundsManager.instance.clickSoundPlayer)
            {
                if (SoundsManager.instance.currentNPC)
                {
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().sounds[SoundsManager.instance.currentNpCAudioPlay].Stop();
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleClick = false;
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.SetActive(false);
                    SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().GlowEffect.SetActive(false);
                    SoundsManager.instance.currentNPC.GetComponent<SpriteRenderer>().material = materialManager.itemOutlineMaterials[0];
                }
                SoundsManager.instance.clickSoundPlayer = true;
                materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor", OutlineColor_0);
                materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor2", OutlineColor_1);
                materialManager.itemOutlineMaterials[1].SetFloat("_OutlineThickness", changeOutline);
                clickAudio.Play();
                material.material = materialManager.itemOutlineMaterials[1];
                if (this.GetComponent<ItemRotate>())
                {
                    this.GetComponent<ItemRotate>().click = true;
                }
                float time = clickAudio.clip.length;
                if (this.GetComponent<Animator>())
                {
                    this.GetComponent<Animator>().SetTrigger("Move");
                }
                Invoke("time", time);
                //if(smartRobotHelper)
                //{
                //    smartRobotHelper.click = true;
                //    smartRobotHelper.Click();
                //}
            }
        }
    }
    private void time()
    {
        if(MoonObj)
        {
            BennyEffect.SetActive(false);
            BennySpeechBubble.SetActive(false);
            SoundsManager.instance.clickSoundPlayer = false;
            material.material = materialManager.itemOutlineMaterials[0];
            if (this.GetComponent<ItemRotate>())
            {
                this.GetComponent<ItemRotate>().click = false;
            }
        }
        else
        {
            SoundsManager.instance.clickSoundPlayer = false;
            material.material = materialManager.itemOutlineMaterials[0];
            if (this.GetComponent<ItemRotate>())
            {
                this.GetComponent<ItemRotate>().click = false;
            }
        }
    }
}
