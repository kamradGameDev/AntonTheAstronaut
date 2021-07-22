using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    public bool click = false;
    public float[] timeProgram;
    public float[] maxTimeProgram;
    public int indexProgram;
    public float timeProgramPause = 5f;
    public float maxTimeProgramPause = 5f;
    public float speedRotation = 0;
    public float[] programSpeed;
    //private bool stopMachine = false;
    private void Start()
    {
        //int random = Random.Range(0, timeProgram.Length);
        //indexProgram = random;
    }
    private void Update()
    {
        if(!click)
        {
            //Debug.Log(indexProgram);
            if (indexProgram == 0)
            {
                if(speedRotation < programSpeed[indexProgram])
                {
                    speedRotation += 0.001f;
                }
                timeProgram[indexProgram] += speedRotation;
                this.transform.Rotate(0, 0, -speedRotation);

            }
            if (indexProgram == 1)
            {
                if (speedRotation < programSpeed[indexProgram])
                {
                    speedRotation += 0.0025f;
                }
                timeProgram[indexProgram] += speedRotation;
                this.transform.Rotate(0, 0, -speedRotation);
            }
            if (indexProgram == 2)
            {
                if (speedRotation < programSpeed[indexProgram])
                {
                    speedRotation += 0.05f;
                }
                timeProgram[indexProgram] += speedRotation;
                this.transform.Rotate(0, 0, -speedRotation);
            }
            if (indexProgram == 3)
            {
                if(speedRotation > programSpeed[indexProgram])
                {
                    speedRotation -= 0.05f;
                }
                this.transform.Rotate(0, 0, -speedRotation);
                if (speedRotation <= programSpeed[indexProgram])
                {
                    indexProgram++;
                }
            }
            if (indexProgram == 4)
            {
                timeProgramPause -= Time.fixedDeltaTime;

                if (this.transform.eulerAngles.z > -29)
                {
                    this.transform.Rotate(0, 0, -0.05f);
                }
                else
                {
                    speedRotation = 0f;
                    this.transform.Rotate(0, 0, speedRotation);
                }
            }
            if(indexProgram < 3)
            {
                if (timeProgram[indexProgram] >= maxTimeProgram[indexProgram])
                {
                    timeProgram[indexProgram] = 0;
                    if (indexProgram < timeProgram.Length - 1)
                    {
                        indexProgram++;
                    }
                }
            }
            
            else if(indexProgram == 4 && timeProgramPause <= 0)
            {
                timeProgramPause = maxTimeProgramPause;
                indexProgram = 0;
            }
        }
    }
}
