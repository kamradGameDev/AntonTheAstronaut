using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GlowEffect : MonoBehaviour
{
    public float speedRotation = 2f;
    public bool right = false;
    public Light2D light2D;
    public Color[] rightColors, leftColors;
    private int random;
    public Color currentColor, nextColor;
    public bool EqualColors;
    private void Start()
    {
        light2D = this.GetComponent<Light2D>();
        InvokeRepeating("RandomSpeed", 0, 1);
        //currentColor = light2D.color;
        //if (right)
        //{
        //    random = Random.Range(0, rightColors.Length);
        //    nextColor = rightColors[random];
        //    light2D.color = rightColors[random];
        //}
        //else
        //{
        //    random = Random.Range(0, leftColors.Length);
        //    nextColor = leftColors[random];
        //    light2D.color = leftColors[random];
        //}
    }
    private void RandomSpeed()
    {
        if(right)
        {
            speedRotation = Random.Range(0.2f, 0.7f);
        }
        else
        {
            speedRotation = Random.Range(-0.2f, -0.7f);
        }
    }
    private void Update()
    {
        this.transform.Rotate(0,0,speedRotation);
        //if (right)
        //{
        //    if(currentColor == nextColor && !EqualColors)
        //    {
        //        EqualColors = true;
        //    }
        //    else
        //    {
        //        if(EqualColors)
        //        {
        //            random = Random.Range(0, rightColors.Length);
        //            //Debug.Log("test right random color");
        //            nextColor = rightColors[random];
        //            EqualColors = false;
        //        }
        //        else
        //        {
        //            light2D.color = Color.Lerp(currentColor, nextColor, Mathf.PingPong(Time.time, 0.05f));
        //            currentColor = light2D.color;
        //        }
        //    }
        //}
        //else
        //{
        //    if(currentColor == nextColor && !EqualColors)
        //    {
                
        //        EqualColors = true;
        //    }
        //    else
        //    {
        //        if (EqualColors)
        //        {
        //            random = Random.Range(0, leftColors.Length);
        //            //Debug.Log("test left random color");
        //            nextColor = leftColors[random];
        //            EqualColors = false;
        //        }
        //        else
        //        {
        //            light2D.color = Color.Lerp(currentColor, nextColor, Mathf.PingPong(Time.time, 0.05f));
        //            currentColor = light2D.color;
        //        }
        //    }
        //}
    }
}
