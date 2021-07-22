using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    private Light2D Lights;
    private float randomDivision, randomIntensivity;
    public float speed = 3f;
    public bool maxLight;
    public float minIntensivity = 0.5f;
    public float maxIntensivity = 1f;
    public bool planet = false;
    public float minRotateZ, maxRotateZ;
    public bool RotateZ = false;
    public float rotationSpeed;
    public float time = 2f;
    private void Start()
    {
        Lights = this.GetComponent<Light2D>();
        int random = Random.Range(-1,1);
        if(random == 0)
        {
            rotationSpeed = Random.Range(2, 5);
        }
        else
        {
            rotationSpeed = Random.Range(-2, -5);
        }
        
        if (!planet)
        {
            randomDivision = Random.Range(20, 25);
        }
        else
        {
            randomDivision = speed;
        }
        randomIntensivity = Random.Range(minIntensivity, maxIntensivity);
        Lights.intensity = randomIntensivity;
    }
    private void Update()
    {
        if(RotateZ)
        {
            if(this.transform.position.z >= maxRotateZ)
            {
                this.transform.Rotate(0,0,Time.fixedDeltaTime * rotationSpeed);
            }
            if (this.transform.position.z <= minRotateZ)
            {
                this.transform.Rotate(0, 0, -Time.fixedDeltaTime * rotationSpeed);
            }
        }
        if(Lights.intensity > minIntensivity && !maxLight)
        {
            Lights.intensity -= Time.fixedDeltaTime / randomDivision;
            if(Lights.intensity <= minIntensivity)
            {
                maxLight = true;
            }
        }
        else if(maxLight)
        {
            Lights.intensity += Time.fixedDeltaTime / randomDivision;
            if(Lights.intensity >= maxIntensivity)
            {
                maxLight = false;
            }
        }
    }
}
