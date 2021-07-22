using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SwipeStatus
{
    noSwipe,
    startSwipe,
    processSwipe,
    processClick,
    endSwipe
}
public class ControlChapter : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static ControlChapter instance;
    //private  ChangeLevels changeLevels;
    private PointsHelper pointsHelper;
    public Sprite[] pointsState;
    public GameObject[] TvObjs;
    //private bool moveRight, moveLeft = false;
    public Vector3[] target = new Vector3[2];
    public int count;
    public float time = 1;
    public GameObject[] tvCurrent;
    private MenuHelper menuHelper;
    public bool click = false;
    public SwipeStatus swipeStatus;
    public float speedSwipe = 20f;
    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }
    private void Start()
    {
        //changeLevels = GameObject.FindObjectOfType<ChangeLevels>();
        pointsHelper = GameObject.FindObjectOfType<PointsHelper>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(GameManager.instance.startChangleLevel && GameManager.instance.AllowSwipe && !GameManager.instance.gameLevel)
        {
            Vector2 delta = eventData.delta;
            if(tvCurrent[0].activeSelf)
            {
                count = TvObjs[0].transform.childCount;
                if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y) && delta.x < 0)
                {
                    Debug.Log("right swipe");
                    if (pointsHelper.activeCount < count)
                    {
                        pointsHelper.activeCount = count;
                        swipeStatus = SwipeStatus.startSwipe;
                        for (int i = 0; i < pointsHelper.count; i++)
                        {
                            if (pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite == pointsState[1])
                            {
                                
                                pointsHelper.activeCount++;
                                pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite = pointsState[0];
                                i++;
                                pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite = pointsState[1];
                                time = 0;
                                
                                for (int j = 0; j < 2; j++)
                                {
                                    TvObjs[j].GetComponent<Animator>().enabled = false;
                                    target[j] = TvObjs[j].transform.position - new Vector3(6, 0, 0);
                                }
                                //Debug.Log(i);

                                break;
                            }
                        }
                    }
                }
                else if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y) && delta.x > 0)
                {
                    if (pointsHelper.activeCount > 0)
                    {
                        pointsHelper.activeCount = 0;
                        swipeStatus = SwipeStatus.startSwipe;
                        for (int i = 0; i < pointsHelper.count; i++)
                        {
                            if (pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite == pointsState[1])
                            {
                                
                                pointsHelper.activeCount--;
                                pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite = pointsState[0];
                                i--;
                                pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite = pointsState[1];
                                time = 0;
                                
                                for (int j = 0; j < 2; j++)
                                {
                                    TvObjs[j].GetComponent<Animator>().enabled = false;
                                    target[j] = TvObjs[j].transform.position + new Vector3(6, 0, 0);
                                }
                                //Debug.Log(i);

                                break;
                            }
                        }
                    }
                }
            }
            else if (tvCurrent[1].activeSelf)
            {
                count = TvObjs[1].transform.childCount;
                if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y) && delta.x < 0)
                {
                    //Debug.Log("Swipe");
                    Debug.Log("left swipe");
                    if (pointsHelper.activeCount < count)
                    {
                        //pointsHelper.activeCount = count;
                        swipeStatus = SwipeStatus.startSwipe;
                        for (int i = 0; i < pointsHelper.count; i++)
                        {
                            if (pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite == pointsState[1])
                            {
                                pointsHelper.activeCount++;
                                pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite = pointsState[0];
                                i++;
                                pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite = pointsState[1];
                                time = 0;
                                
                                for (int j = 0; j < 2; j++)
                                {
                                    TvObjs[j].GetComponent<Animator>().enabled = false;
                                    //TvObjs[j].GetComponent<ScenarioTV>().thisTransform -= TvObjs[j].GetComponent<ScenarioTV>().transform.position + new Vector3(6, 0, 0);
                                    target[j] = TvObjs[j].transform.position - new Vector3(6, 0, 0);
                                }
                                //Debug.Log(i);

                                break;
                            }
                        }
                    }
                }
                else if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y) && delta.x > 0)
                {
                    if (pointsHelper.activeCount > 0)
                    {
                        //pointsHelper.activeCount = 0;
                        swipeStatus = SwipeStatus.startSwipe;
                        for (int i = 0; i < pointsHelper.count; i++)
                        {
                            if (pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite == pointsState[1])
                            {
                                
                                pointsHelper.activeCount--;
                                pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite = pointsState[0];
                                i--;
                                pointsHelper.pointsObj[i].GetComponent<SpriteRenderer>().sprite = pointsState[1];
                                time = 0;
                                
                                for (int j = 0; j < 2; j++)
                                {
                                    TvObjs[j].GetComponent<Animator>().enabled = false;
                                    //TvObjs[j].GetComponent<ScenarioTV>().thisTransform += TvObjs[j].GetComponent<ScenarioTV>().transform.position + new Vector3(6, 0,0);
                                    target[j] = TvObjs[j].transform.position + new Vector3(6, 0, 0);
                                }
                                //Debug.Log(i);

                                break;
                            }
                        }
                    }
                }
            }
                
        } 
    }
    private void Update()
    {
        if(swipeStatus == SwipeStatus.processSwipe)
        {
            time += Time.fixedDeltaTime;
        }
        if (swipeStatus == SwipeStatus.endSwipe && GameManager.instance.AllowSwipe)
        {
            if (TvObjs[1].transform.parent.gameObject.activeSelf)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (TvObjs[j].transform.position != target[j])
                    {
                        //TvObjs[j].transform.position = Vector3.MoveTowards(TvObjs[j].transform.position, target[j], 30f * Time.deltaTime);
                        TvObjs[j].transform.position = Vector2.Lerp(TvObjs[j].transform.position, target[j], speedSwipe * Time.fixedDeltaTime);
                        //Debug.Log("test position");
                    }
                    else
                    {
                        time = 0;
                        //swipeStatus = SwipeStatus.noSwipe;
                    }
                }
            }
            else
            {
                GameObject obj = GameObject.FindGameObjectWithTag("TV");
                for (int i = 0; i < 2; i++)
                {
                    TvObjs[i] = obj.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        swipeStatus = SwipeStatus.endSwipe;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(swipeStatus == SwipeStatus.startSwipe)
        {
            //GameManager.instance.AllowSwipe = false;
            swipeStatus = SwipeStatus.processSwipe;
        }
    }
}
