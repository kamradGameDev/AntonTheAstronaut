using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public GameObject GlobalLight;
    private void Start()
    {
        //SoundsManager.instance.audiosMusic[SoundsManager.instance.currentAudioPlay].Pause();
        //SoundsManager.instance.RandomMusicGameLevel();
        /*foreach(GameObject rootObject in SceneManager.GetSceneByBuildIndex(0).GetRootGameObjects())
        {
            if(rootObject.name == "SoundsManager")
            {
                Debug.Log("SoundsManager: " + rootObject.name);
            }
        }*/
    }
    public void backToMenu(int currentLevelIndex)
    {
        GlobalLight.SetActive(false);
        AsyncOperation async = SceneManager.UnloadSceneAsync(currentLevelIndex);
        async.allowSceneActivation = false;
        GameManager.instance.menuSceneObj.SetActive(true);
        SceneManager.UnloadSceneAsync(currentLevelIndex);


        GameManager.instance.globalLight.gameObject.SetActive(true);
        SoundsManager.instance.clickSoundPlayer = false;
        //SoundsManager.instance.audiosMusic[SoundsManager.instance.currentAudioPlay].Play();
        //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        //SceneManager.LoadSceneAsync(0);
        GameManager.instance.AllowSwipe = false;
        GameManager.instance.gameLevel = false;
        GameManager.instance.timeChangeSwipeStatus = 0;
        //Scene gameScene = SceneManager.GetSceneByBuildIndex(0);
        //SceneManager.SetActiveScene(gameScene);

        //SceneManager.MoveGameObjectToScene(SoundsManager.instance.gameObject, SceneManager.GetSceneByBuildIndex(0));

        
        GameManager.instance.menuCanvas.SetActive(true);
        if (MenuManager.instance.backButtonAnim.GetCurrentAnimatorStateInfo(0).IsName("Default") || MenuManager.instance.backButtonAnim.GetCurrentAnimatorStateInfo(0).IsName("Close") || MenuManager.instance.backButtonAnim.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            MenuManager.instance.backButtonAnim.SetTrigger("Open");
        }
        
        //MenuManager.instance.backButtonAnim.transform.position = new Vector3(-780, 415, 0);
    }
}
