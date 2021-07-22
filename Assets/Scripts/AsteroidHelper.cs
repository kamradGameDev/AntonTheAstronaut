using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHelper : MonoBehaviour
{
    public float speed = 0.01f;
    public float speedAlpha = 2f;
    public float speedRotation = 2f;
    private SpriteRenderer spriteRenderer;
    public float targetPosEnd = 4.4f;
    public float targetPosStart = 3.5f;
    public bool movedCurrentEndPos = false;
    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        speedRotation = Random.Range(0f, 0.15f);
        speedAlpha = speed * 20f;
    }
    private void Update()
    {
        this.transform.Rotate(0, 0, speedRotation);
        if (this.transform.position.x < targetPosEnd && !movedCurrentEndPos)
        {
            //Debug.Log("test pos_1");
            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(targetPosEnd, this.transform.position.y), speed * Time.fixedDeltaTime);
            
            //this.transform.position = Vector2.Lerp(this.transform.position, new Vector2(4.6f, this.transform.position.y), 0.01f);
        }
        else if(this.transform.position.x >= targetPosEnd && !movedCurrentEndPos)
        {
            //Debug.Log("test pos_2");
            Color color = spriteRenderer.color;
            if(color.a > 0)
            {
                color.a -= Time.fixedDeltaTime * speedAlpha;
                spriteRenderer.color = color;
            }
            else
            {
                movedCurrentEndPos = true;
            }
            //this.transform.position = new Vector2(3.5f, this.transform.position.y); 
        }
        else if(movedCurrentEndPos)
        {
            if (this.transform.position.x > targetPosStart)
            {
                //Debug.Log("test pos_3");
                this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(targetPosStart, this.transform.position.y), speed * 5f * Time.fixedDeltaTime);
            }
            else
            {
                Color color = spriteRenderer.color;
                if (color.a < 1)
                {
                    //Debug.Log("test pos_4");
                    color.a += Time.fixedDeltaTime * speedAlpha;
                    spriteRenderer.color = color;
                }
                else
                {
                    movedCurrentEndPos = false;
                }
                
            }
            
        }
    }
}
