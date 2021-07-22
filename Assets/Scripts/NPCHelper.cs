using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class NPCHelper : MonoBehaviour
{
    public AudioSource[] sounds;
    public int countClick = 0;
    //private bool soundPlayer = false;
    //public float plus = 0.2f;
    private float timeSound;
    private int bgMusicIndex;
    public GameObject bubbleObj;
    public bool bubbleClick = false;
    private SpriteRenderer material;
    public float changeOutline = 1f;
    public Color OutlineColor_0, OutlineColor_1;
    private MaterialManager materialManager;
    public GameObject GlowEffect;
    private void Start()
    {
        changeOutline = 1f;
        OutlineColor_0 = Color.red;
        OutlineColor_1 = Color.green;
        material = this.GetComponent<SpriteRenderer>();
        materialManager = GameObject.FindObjectOfType<MaterialManager>();
        material = this.GetComponent<SpriteRenderer>();
        GlowEffect = this.transform.Find("GlowEffect").gameObject;
    }
    private void OnMouseDown()
    {
        if(!SoundsManager.instance.clickSoundPlayer && bubbleObj)
        {
            for (int i = 0; i < sounds.Length; i++)
            {
                if (SoundsManager.instance.currentNPC != null)
                {
                    if (countClick == sounds.Length)
                    {
                        countClick = 0;
                    }
                    if (countClick < sounds.Length)
                    {
                        if(sounds[countClick])
                        {
                            SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().sounds[SoundsManager.instance.currentNpCAudioPlay].Stop();
                            SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleClick = false;
                            SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().GlowEffect.SetActive(false);
                            SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
                            SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
                            SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.SetActive(false);
                            //SoundsManager.instance.currentNPC.GetComponent<SpriteRenderer>().material = materialManager.itemOutlineMaterials[0];
                            sounds[countClick].Play();
                            GlowEffect.SetActive(true);

                            //GlowEffect.transform.GetChild(0).GetComponent<Light2D>().color =
                            //    GlowEffect.transform.GetChild(0).GetComponent<GlowEffect>().rightColors[Random.Range(0, GlowEffect.transform.GetChild(0).GetComponent<GlowEffect>().rightColors.Length)];
                            //GlowEffect.transform.GetChild(1).GetComponent<Light2D>().color =
                            //    GlowEffect.transform.GetChild(1).GetComponent<GlowEffect>().leftColors[Random.Range(0, GlowEffect.transform.GetChild(1).GetComponent<GlowEffect>().leftColors.Length)];

                            bubbleClick = true;
                            bubbleObj.SetActive(true);
                            bubbleObj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                            bubbleObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255f);
                            //material.material = materialManager.itemOutlineMaterials[1];
                            //materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor", OutlineColor_0);
                            //materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor2", OutlineColor_1);
                            //materialManager.itemOutlineMaterials[1].SetFloat("_OutlineThickness", changeOutline);
                            SoundsManager.instance.currentNPC = this.gameObject;
                            SoundsManager.instance.currentNpCAudioPlay = countClick;
                            timeSound = sounds[countClick].clip.length;
                            //Invoke("TimeSound", timeSound);
                            countClick++;
                            break;
                        }
                    }
                }
                else
                {
                    if (countClick == sounds.Length)
                    {
                        countClick = 0;
                    }
                    if (countClick < sounds.Length)
                    {
                        if (countClick == 0)
                        {
                            sounds[countClick].Play();
                            GlowEffect.SetActive(true);

                            //GlowEffect.transform.GetChild(0).GetComponent<Light2D>().color =
                            //    GlowEffect.transform.GetChild(0).GetComponent<GlowEffect>().rightColors[Random.Range(0, GlowEffect.transform.GetChild(0).GetComponent<GlowEffect>().rightColors.Length)];
                            //GlowEffect.transform.GetChild(1).GetComponent<Light2D>().color =
                            //    GlowEffect.transform.GetChild(1).GetComponent<GlowEffect>().leftColors[Random.Range(0, GlowEffect.transform.GetChild(1).GetComponent<GlowEffect>().leftColors.Length)];
                            SoundsManager.instance.currentNpCAudioPlay = countClick;

                            //SoundsManager.instance.clickSoundPlayer = true;
                            timeSound = sounds[countClick].clip.length;
                            //Invoke("TimeSound", timeSound);
                            SoundsManager.instance.currentNPC = this.gameObject;
                            for (int k = 0; k < SoundsManager.instance.audiosMusic.Length; k++)
                            {
                                if (SoundsManager.instance.audiosMusic[k].isPlaying)
                                {
                                    SoundsManager.instance.audiosMusic[k].volume = 0.02f;
                                    bgMusicIndex = k;
                                    break;
                                }
                            }
                            //SoundsManager.instance.clickSoundPlayer = true;
                            //materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor", OutlineColor_0);
                            //materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor2", OutlineColor_1);
                            //materialManager.itemOutlineMaterials[1].SetFloat("_OutlineThickness", changeOutline);
                            //material.material = materialManager.itemOutlineMaterials[1];
                            
                            /*this.transform.localScale += new Vector3(plus, plus, plus);
                            if(this.transform.childCount > 0)
                            {
                                for(int j = 0; j < this.transform.childCount; j++)
                                {
                                    this.transform.GetChild(j).localScale += new Vector3(plus, plus, plus);
                                }
                            }*/

                            bubbleClick = true;
                            if(bubbleObj)
                            {
                                bubbleObj.SetActive(true);
                                bubbleObj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                                bubbleObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                            }

                            //Debug.Log(countClick);
                            countClick++;
                            break;
                        }
                        else
                        {
                            //SoundsManager.instance.clickSoundPlayer = true;
                            timeSound = sounds[countClick].clip.length;
                            //Invoke("TimeSound", timeSound);
                            sounds[countClick].Play();
                            GlowEffect.SetActive(true);

                            //GlowEffect.transform.GetChild(0).GetComponent<Light2D>().color =
                            //    GlowEffect.transform.GetChild(0).GetComponent<GlowEffect>().rightColors[Random.Range(0, GlowEffect.transform.GetChild(0).GetComponent<GlowEffect>().rightColors.Length)];
                            //GlowEffect.transform.GetChild(1).GetComponent<Light2D>().color =
                            //    GlowEffect.transform.GetChild(1).GetComponent<GlowEffect>().leftColors[Random.Range(0, GlowEffect.transform.GetChild(1).GetComponent<GlowEffect>().leftColors.Length)];

                            SoundsManager.instance.currentNpCAudioPlay = countClick;
                            SoundsManager.instance.currentNPC = this.gameObject;
                            for (int k = 0; k < SoundsManager.instance.audiosMusic.Length; k++)
                            {
                                if (SoundsManager.instance.audiosMusic[k].isPlaying)
                                {
                                    SoundsManager.instance.audiosMusic[k].volume = 0.02f;
                                    bgMusicIndex = k;
                                    break;
                                }
                            }
                            //materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor", OutlineColor_0);
                            //materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor2", OutlineColor_1);
                            //materialManager.itemOutlineMaterials[1].SetFloat("_OutlineThickness", changeOutline);
                            //material.material = materialManager.itemOutlineMaterials[1];
                            /*this.transform.localScale += new Vector3(plus, plus, plus);
                            if(this.transform.childCount > 0)
                            {
                                for(int j = 0; j < this.transform.childCount; j++)
                                {
                                    this.transform.GetChild(j).localScale += new Vector3(plus, plus, plus);
                                }
                            }*/
                            
                            bubbleClick = true;
                            if (bubbleObj)
                            {
                                bubbleObj.SetActive(true);
                                bubbleObj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                                bubbleObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                            }
                            //Debug.Log(countClick);
                            countClick++;
                            break;
                        }
                    }
                }
            }
        }
        
    }
    private void Update()
    {
        if (bubbleClick)
        {
            timeSound -= Time.deltaTime;
            if(timeSound <= 0)
            {
                bubbleClick = false;
                bubbleObj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
                bubbleObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
                //SoundsManager.instance.clickSoundPlayer = false;
                //material.material = materialManager.itemOutlineMaterials[0];
                GlowEffect.SetActive(false);
                //bubbleObj.SetActive(false);
                for (int k = 0; k < SoundsManager.instance.audiosMusic.Length; k++)
                {
                    if (k == bgMusicIndex)
                    {
                        SoundsManager.instance.currentNPC = null;
                        SoundsManager.instance.audiosMusic[k].volume = 0.2f;
                        break;
                    }
                }
            }
        }
    }
}
