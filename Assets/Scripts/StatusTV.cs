using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatusTV : MonoBehaviour
{
    public bool status = false;
    public bool move = false;
    public bool chapter = false;
    public int index = 1;
    public bool thisObjSceneLoad = true;
    private AsyncOperation unloadTask;
    private bool loadScene;
    public bool TvEnabled;
    public bool endOpenAnim;
    private void OnMouseDown()
    {
        //ControlChapter.instance.swipeStatus = SwipeStatus.processSwipe;
    }
    private void OnMouseUp()
    {
        if (MenuManager.instance.levelLoadingPermission && status && thisObjSceneLoad && TvEnabled && (ControlChapter.instance.swipeStatus == SwipeStatus.endSwipe || ControlChapter.instance.swipeStatus == SwipeStatus.noSwipe))
        {
            Debug.Log("Load game scene 1");
            //GameManager.instance.globalLight.intensity = 0.7f;
            //GameManager.instance.menuCanvas.SetActive(false);
            GameManager.instance.AllowSwipe = false;
            GameManager.instance.gameLevel = true;
            //GameManager.instance.GlobalLightObj.SetActive(false);
            //SoundsManager.instance.scenariousMusic.Pause();
            //SoundsManager.instance.scenariousMusic.gameObject.SetActive(false);

            SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
            Invoke("TimeLoadScene", 0.2f);
            //SceneManager.MoveGameObjectToScene(SoundsManager.instance.gameObject, SceneManager.GetSceneByBuildIndex(index));
            //SceneManager.LoadScene(index);
        }
        else
        {
            
            ControlChapter.instance.swipeStatus = SwipeStatus.endSwipe;
        }
    }
    private void TimeLoadScene()
    {
        GameManager.instance.menuSceneObj.SetActive(false);
    }
    private void EndOpenAnim()
    {
        if (endOpenAnim && this.transform.parent.GetComponent<Animator>())
        {
            //this.transform.parent.GetComponent<Animator>().enabled = false;
        }
        else if(endOpenAnim && !this.transform.parent.GetComponent<Animator>())
        {
            //this.GetComponent<Animator>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "ColTvStatus")
        {
            if(this.gameObject.name == "TV")
            {
                status = true;
                //ControlChapter.instance.test = true;
                //GameManager.instance.swipeStatus = status;
                //this.transform.localScale = new Vector3(0.9186f, 0.948f, 1f);
            }
            else
            {
                status = true;
                //ControlChapter.instance.test = true;
                //GameManager.instance.swipeStatus = status;
                //this.transform.localScale = new Vector3(1.31f, 1.35f, 1f);
            }
            
        }
        if(col.name == "BG")
        {
            //this.transform.localScale = new Vector3(0.926f, 0.943f, 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        //if(col.name == "ColTvStatus")
        //{
            if(this.gameObject.name == "TV")
            {
                status = false;
                //ControlChapter.instance.test = false;
                //GameManager.instance.swipeStatus = status;
                //this.transform.localScale = new Vector3(0.653f, 0.693f, 1f);
            }
            else
            {
                status = false;
                //ControlChapter.instance.test = false;
                //GameManager.instance.swipeStatus = status;
                //this.transform.localScale = new Vector3(0.926f, 0.943f, 1f);
        }
        //}
    }
    private void Update()
    {
        if(move)
        {
            if(this.gameObject.name == "TV" && !status)
            {
                if(this.transform.localScale.x > 0.653f)
                {
                    this.transform.localScale -= new Vector3(GameManager.instance.speedStatusTvLocalScale, 0f, 0) * Time.fixedDeltaTime;
                }
                if(this.transform.localScale.y > 0.693f)
                {
                    this.transform.localScale -= new Vector3(0f, GameManager.instance.speedStatusTvLocalScale, 0) * Time.fixedDeltaTime;
                }
            }
            else if(this.gameObject.name == "TV" && status)
            {
                if(this.transform.localScale.x < 0.9186f)
                {
                    this.transform.localScale += new Vector3(GameManager.instance.speedStatusTvLocalScale, 0f, 0) * Time.fixedDeltaTime;
                }
                if(this.transform.localScale.y < 0.948f)
                {
                    this.transform.localScale += new Vector3(0f, GameManager.instance.speedStatusTvLocalScale, 0) * Time.fixedDeltaTime;
                }
            }
            else if(this.gameObject.name != "TV" && status && chapter)
            {
                if(this.transform.localScale.x < 1.31f)
                {
                    this.transform.localScale += new Vector3(GameManager.instance.speedStatusTvLocalScale, 0f, 0) * Time.fixedDeltaTime;
                }
                if(this.transform.localScale.y < 1.35f)
                {
                    this.transform.localScale += new Vector3(0f, GameManager.instance.speedStatusTvLocalScale, 0) * Time.fixedDeltaTime;
                }
            }
            else if(this.gameObject.name != "TV" && !status && chapter)
            {
                if(this.transform.localScale.x > 0.926f)
                {
                    this.transform.localScale -= new Vector3(GameManager.instance.speedStatusTvLocalScale, 0f, 0) * Time.fixedDeltaTime;
                }
                if(this.transform.localScale.y > 0.943f)
                {
                    this.transform.localScale -= new Vector3(0f, GameManager.instance.speedStatusTvLocalScale, 0) * Time.fixedDeltaTime;
                }
            }
            else if(this.gameObject.name != "TV" && status && !chapter)
            {
                if(this.transform.localScale.x < 0.91f)
                {
                    this.transform.localScale += new Vector3(GameManager.instance.speedStatusTvLocalScale, 0f, 0) * Time.fixedDeltaTime;
                }
                if(this.transform.localScale.y < 0.93f)
                {
                    this.transform.localScale += new Vector3(0f, GameManager.instance.speedStatusTvLocalScale, 0) * Time.fixedDeltaTime;
                }
            }
            else if(this.gameObject.name != "TV" && !status && !chapter)
            {
                if(this.transform.localScale.x > 0.655f)
                {
                    this.transform.localScale -= new Vector3(GameManager.instance.speedStatusTvLocalScale, 0f, 0) * Time.fixedDeltaTime;
                }
                if(this.transform.localScale.y > 0.674f)
                {
                    this.transform.localScale -= new Vector3(0f, GameManager.instance.speedStatusTvLocalScale, 0) * Time.fixedDeltaTime;
                }
            }
        }
    }
}
