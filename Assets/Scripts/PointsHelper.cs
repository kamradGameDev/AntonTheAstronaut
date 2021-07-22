using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsHelper : MonoBehaviour
{
    public int count = 5;
    public GameObject[] pointsObj;
    public int activeCount = 0;
    private void Start()
    {
        /*for (int i = 0; i < count; i++)
        {
            pointsObj[i] = this.transform.GetChild(i).gameObject;
        }*/
    }
    public void  StartPoints(int _count)
    {
        count = _count;
        //Debug.Log("Point counts: " + count);
        for (int i = 0; i < 4; i++)
        {
            pointsObj[i] = this.transform.GetChild(i).gameObject;
            this.transform.GetChild(i).localScale = new Vector3(0, 0, 0);
        }
        StartCoroutine("PointMove", 3f);
    }
    private IEnumerator PointMove()
    {

        for (int i = 0; i < count; i++)
        {
            if (this.transform.GetChild(i).localScale != new Vector3(1, 1, 1))
            {
                //Debug.Log("Start coroutine test");
                this.transform.GetChild(i).localScale = new Vector3(1, 1, 1);
                yield return new WaitForSeconds(0.2f);
            }
            //else
            //{
            //    //StopCoroutine("PointMove");
            //}
        }
    }
}
