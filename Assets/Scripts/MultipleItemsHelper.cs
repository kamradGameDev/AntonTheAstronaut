using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleItemsHelper : MonoBehaviour
{
    public AudioSource clickAudio;
    public GameObject[] items;
    public SpriteRenderer[] materials;
    public float changeOutline = 0.1f;
    public Color OutlineColor_0, OutlineColor_1;
    private MaterialManager materialManager;
    private void Start()
    {
        //Debug.Log(this.name);
        OutlineColor_0 = Color.red;
        OutlineColor_1 = Color.blue;
        for (int i = 0; i < items.Length; i++)
        {
            materials[i] = items[i].GetComponent<SpriteRenderer>();
        }
        materialManager = GameObject.FindObjectOfType<MaterialManager>();
    }
    private void OnMouseDown()
    {
        if (!SoundsManager.instance.clickSoundPlayer)
        {
            if (SoundsManager.instance.currentNPC)
            {
                SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().sounds[SoundsManager.instance.currentNpCAudioPlay].Stop();
                SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleClick = false;
                SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
                SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
                SoundsManager.instance.currentNPC.GetComponent<NPCHelper>().bubbleObj.SetActive(false);
                SoundsManager.instance.currentNPC.GetComponent<SpriteRenderer>().material = materialManager.itemOutlineMaterials[0];
            }
            SoundsManager.instance.clickSoundPlayer = true;
            materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor", OutlineColor_0);
            materialManager.itemOutlineMaterials[1].SetColor("_OutlineColor2", OutlineColor_1);
            materialManager.itemOutlineMaterials[1].SetFloat("_OutlineThickness", changeOutline);
            clickAudio.Play();
            for (int i = 0; i < items.Length; i++)
            {
                materials[i].material = materialManager.itemOutlineMaterials[1];
            }
            float time = clickAudio.clip.length;
            Invoke("time", time);
        }
    }
        
    private void time()
    {
        SoundsManager.instance.clickSoundPlayer = false;
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].material = materialManager.itemOutlineMaterials[0];
        }
    }
}
