using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsHelper : MonoBehaviour
{
    public Animator settingMenuAnimator;
    public SpriteRenderer SettingMenuSpriteRenderer;
    public Sprite[] SettingsSoundOnOf;
    public void ActiveSettingsMenu()
    {
        if(SoundsManager.instance.OneScreen)
        {
            if (!GameManager.instance.clickSetting)
            {
                settingMenuAnimator.SetTrigger("Open");
                GameManager.instance.clickTvStatus = false;
                GameManager.instance.clickSetting = true;
            }
            else
            {
                settingMenuAnimator.SetTrigger("Close");
                GameManager.instance.clickTvStatus = true;
                GameManager.instance.clickSetting = false;
            }
        }
    }
    
}
