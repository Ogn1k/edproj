using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite spriteOn;
    public Sprite spriteOff;

    protected int actin;
    public static bool toggle;
    
    protected GameObject obj;
    
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        actin++;
        obj = collision.gameObject.transform.GetChild(0).gameObject;
        //Debug.Log(block());
    }
    public void OnTriggerExit2D()
    {
        actin--;
        obj = null;
    }
    protected virtual void Update()
    {
        if (actin != 0)
        {
            toggle = false;
            spriteRenderer.sprite = spriteOn;
        }
        else
        {
            spriteRenderer.sprite = spriteOff;
            toggle = true;
        }
        
    }

    public virtual string block()
    {
        if (obj != null)
        {
            if (obj.CompareTag("A"))
                return "A";
            if (obj.CompareTag("B"))
                return "B";
            if (obj.CompareTag("C"))
                return "C";
            if (obj.CompareTag("!"))
                return "!";
            if (obj.CompareTag("&"))
                return "&";
        }
        return null;
    }
}
