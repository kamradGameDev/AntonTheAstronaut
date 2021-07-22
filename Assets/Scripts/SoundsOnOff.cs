using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsOnOff : MonoBehaviour
{
    private SettingsHelper settingsHelper;
    private void Start()
    {
        settingsHelper = GameObject.FindObjectOfType<SettingsHelper>();
    }
    private void OnMouseDown()
    {
        if (GameManager.instance.soundOn)
        {
            //AudioListener.volume = 0;
            GameManager.instance.clickTvStatus = true;
            GameManager.instance.clickSetting = false;
            settingsHelper.settingMenuAnimator.SetTrigger("Close");
            GameManager.instance.soundOn = false;
            SoundsManager.instance.audiosMusic[SoundsManager.instance.currentAudioPlay].volume = 0;
            SoundsManager.instance.scenariousMusic.volume = 0;
            settingsHelper.SettingMenuSpriteRenderer.sprite = settingsHelper.SettingsSoundOnOf[1];
        }
        else
        {
            //AudioListener.volume = 1;
            GameManager.instance.clickTvStatus = true;
            GameManager.instance.clickSetting = false;
            settingsHelper.settingMenuAnimator.SetTrigger("Close");
            GameManager.instance.soundOn = true;
            SoundsManager.instance.audiosMusic[SoundsManager.instance.currentAudioPlay].volume = 0.2f;
            SoundsManager.instance.scenariousMusic.volume = 0.2f;
            settingsHelper.SettingMenuSpriteRenderer.sprite = settingsHelper.SettingsSoundOnOf[0];
        }
    }
}
