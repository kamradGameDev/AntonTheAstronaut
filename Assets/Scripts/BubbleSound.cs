using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSound : MonoBehaviour
{
    public static BubbleSound instance;
    public AudioSource sound;
    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }
}
