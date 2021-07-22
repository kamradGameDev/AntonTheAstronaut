using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleLive : MonoBehaviour
{
    private void Start()
    {
        Invoke("TimeLive", Random.Range(2.5f, 5f));
        //Destroy(this.gameObject, Random.Range(2.5f, 5f));
    }
    private void TimeLive()
    {
        SoundsManager.instance.clickSoundPlayer = false;
        Destroy(this.gameObject);
    }
}
