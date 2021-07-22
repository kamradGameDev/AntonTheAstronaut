using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapBubbleManager : MonoBehaviour
{
    public float[] VectorX;
    public float[] VectorY;
    public GameObject[] bubblesObj;
    public List<SpriteRenderer> bubbles;
    private void Start()
    {
        InvokeRepeating("GenereteBubbles",Random.Range(1, 3),Random.Range(1, 8));
    }
    private void GenereteBubbles()
    {
        float randomX = Random.Range(VectorX[0], VectorX[1]);
        float randomY = Random.Range(VectorY[0], VectorY[1]);
        int randomObj = Random.Range(0, bubblesObj.Length);
        GameObject obj = Instantiate(bubblesObj[randomObj]);
        obj.transform.position = new Vector2(randomX, randomY);
        obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Random.Range(2, 6));
        bubbles.Add(obj.GetComponent<SpriteRenderer>());
        //Destroy(obj, Random.Range(2.5f, 5f));
    }
    private void Update()
    {
        for(int i = 0; i < bubbles.Count; i++)
        {
            if(bubbles[i])
            {
                float alpha = bubbles[i].color.a;
                if(alpha < 255)
                {
                    bubbles[i].color += new Color(0,0,0, Time.fixedDeltaTime / Random.Range(15, 20));
                }
                if (bubbles[i].transform.localScale.x < 1 && bubbles[i].transform.localScale.y < 1)
                {
                    bubbles[i].transform.localScale += new Vector3(Time.fixedDeltaTime / Random.Range(6, 9), Time.fixedDeltaTime / Random.Range(6, 9));
                }
            }
            else
            {
                bubbles.Remove(bubbles[i]);
            }
        }
    }
}
