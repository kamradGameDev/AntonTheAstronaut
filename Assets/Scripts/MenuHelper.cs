using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHelper : MonoBehaviour
{
    public static MenuHelper instance;
    public GameObject tvImage, Headline, Footer;
    private Animator animTvImage, /*animHeadline,*/ animFooter;
    //public SpriteRenderer BgGrey;
    public GameObject BG_Start;
    public Sprite bGBlur;
    public float speedAlpha = 2f;
    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        animTvImage = tvImage.GetComponent<Animator>();
        
        //animHeadline = Headline.GetComponent<Animator>();
        animFooter = Footer.GetComponent<Animator>();
    }
    public void OnMouseDown()
    {
        if(!GameManager.instance.startScene && !GameManager.instance.startClick && animTvImage)
        {
            animFooter.SetTrigger("Open");
            animTvImage.SetTrigger("Open");
            MenuManager.instance.headLineState[0].GetComponent<Animator>().SetTrigger("Open_1");
            //animHeadline.SetTrigger("Open_1");
            GameManager.instance.startScene = true;
            GameManager.instance.startClick = true;
        }
    }
    private void Update()
    {
        if (GameManager.instance.startScene)
        {
            if(BG_Start.activeSelf)
            {
                Color greyColorBG = MenuManager.instance.BgDark.color;
                if(greyColorBG.a < 0.45f)
                {
                    greyColorBG.a += speedAlpha * Time.fixedDeltaTime;
                    MenuManager.instance.BgDark.color = greyColorBG;
                    //Debug.Log("test color a: " + greyColorBG.a);
                }
                else
                {
                    GameManager.instance.startScene = false;
                }
                //Color colorBG = BG_Start.GetComponent<SpriteRenderer>().color;
                //if (colorBG.a > 0.47f)
                //{
                //    colorBG.a -= speedAlpha * Time.deltaTime;
                //    BG_Start.GetComponent<SpriteRenderer>().color = colorBG;
                //}
                //for (int i = 0; i < GameManager.instance.Items.transform.childCount; i++)
                //{
                //    Color color = GameManager.instance.Items.transform.GetChild(i).GetComponent<SpriteRenderer>().color;
                //    if(GameManager.instance.Items.transform.GetChild(i).Find("GlowEffect"))
                //    {
                //        Debug.Log("Glow effect");
                //    }
                //    if (color.a > 0.27f)
                //    {
                //        color.a -= speedAlpha * Time.deltaTime;
                //        GameManager.instance.Items.transform.GetChild(i).GetComponent<SpriteRenderer>().color = color;
                //    }
                //    else
                //    {
                //        GameManager.instance.startScene = false;
                //        break;
                //    }
                //}
            }
        }
    }
}
