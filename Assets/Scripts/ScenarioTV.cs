using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioTV : MonoBehaviour
{
    public Vector3 thisTransform;
    private void Start()
    {
        //thisTransform = this.transform.position;
    }
    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, thisTransform, 30f * Time.fixedDeltaTime);
    }
}
