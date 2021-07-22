using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoamHelper : MonoBehaviour
{
    public float shake;
    public int status;
    public bool statusProgress = false;
    public GameObject item;
    private ItemRotate itemRotate;
    private void Start()
    {
        //VectorX[0] = Random.Range(0.01f, 0.02f);
        //VectorX[1] = Random.Range(0.01f, 0.02f);

        //VectorY[0] = Random.Range(0.01f, 0.02f);
        //VectorY[1] = Random.Range(0.01f, 0.02f);
        itemRotate = item.GetComponent<ItemRotate>();
        InvokeRepeating("FoamChange", 0.1f, 0.02f);
    }
    private void FoamChange()
    {
        if(!itemRotate.click && itemRotate.speedRotation != 0)
        {
            shake = itemRotate.speedRotation / 1100;
            if (status == 0 && !statusProgress)
            {
                status = 1;
                this.transform.position += new Vector3(shake, 0, 0);
                statusProgress = true;
                Invoke("time", 0.05f);
            }
            if (status == 1 && !statusProgress)
            {
                this.transform.position -= new Vector3(shake, 0, 0);
                statusProgress = true;
                status = 2;
                Invoke("time", 0.05f);
            }
            if (status == 2 && !statusProgress)
            {
                this.transform.position += new Vector3(0, shake, 0);
                statusProgress = true;
                status = 3;
                Invoke("time", 0.05f);
            }
            if (status == 3 && !statusProgress)
            {
                this.transform.position -= new Vector3(0, shake, 0);
                statusProgress = true;
                status = 0;
                Invoke("time", 0.05f);
            }
        }
    }
    private void time()
    {
        statusProgress = false;
    }
}
