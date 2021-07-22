using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SmartRobotHelper : MonoBehaviour
{
    public Light2D[] light2D;
    private float nextTime;
    public Color[] colors;
    //public bool click;
    //public int countLights;
    private void Start()
    {
        nextTime = Random.Range(1, 3);
        InvokeRepeating("RandomLights", nextTime, nextTime);
    }
    private void RandomLights()
    {
        //if (!click)
        //{
            nextTime = Random.Range(1, 5);
            int random = Random.Range(0, light2D.Length);
            float randomLight = Random.Range(0.5f, 1f);
            int randomColor = Random.Range(0, 5);
            for (int i = 0; i < light2D.Length; i++)
            {
                if (light2D[random])
                {
                    light2D[random].intensity = randomLight;
                    light2D[random].color = colors[randomColor];
                }
                else
                {
                    light2D[i].intensity = 0;
                    light2D[i].color = colors[6];
                }
            }
        //}
    }
    //public void Click()
    //{
    //    StartCoroutine("ClickLights");
    //}
    //public IEnumerator ClickLights()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    countLights++;
    //    if(countLights <= 10)
    //    {
    //        int random = Random.Range(0, light2D.Length);
    //        float randomLight = Random.Range(0.5f, 1f);
    //        int randomColor = Random.Range(0, 5);
    //        for (int i = 0; i < light2D.Length; i++)
    //        {
    //            if (light2D[random])
    //            {
    //                light2D[random].intensity = randomLight;
    //                light2D[random].color = colors[randomColor];
    //            }
    //            else
    //            {
    //                light2D[i].intensity = 0;
    //                light2D[i].color = colors[6];
    //            }
    //        }
    //    }
    //    else
    //    {
    //        click = false;
    //        countLights = 0;
    //        for (int i = 0; i < light2D.Length; i++)
    //        {
    //            light2D[i].intensity = 0;
    //            light2D[i].color = colors[6];
    //        }
    //        StopCoroutine("ClickLights");
    //    }
    //}
}
