using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite spriteOn;
    public Sprite spriteOff;

    private int actin;
    public static bool toggle;

   // public Transform cde;
    //public Transform ode;
    private GameObject obj;

    //public bool OnTriggerEnter2D()
    //{
    //    return true;
    //}
    private void OnTriggerEnter2D(Collider2D collision)
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
    private void Update()
    {
        if (actin != 0)
        {
            toggle = false;
            spriteRenderer.sprite = spriteOn;
            //doorOpen(cde, ode);


        }
        else
        {
            spriteRenderer.sprite = spriteOff;
            toggle = true;
            //doorClose(cde, ode);
        }
        
    }

    private void FixedUpdate()
    {
        
    }

    public string block()
    {
        if (obj != null)
        {
            if (obj.CompareTag("A"))
                return "A";
            if (obj.CompareTag("!"))
                return "!";
        }
        return null;
    }
    /*
    public bool doorOpen(Transform cd, Transform od)
    {

        cd.gameObject.SetActive(false);

        od.gameObject.SetActive(true);


        return true;
    }
    public bool doorClose(Transform cd, Transform od)
    {

        cd.gameObject.SetActive(true);

        od.gameObject.SetActive(false);

        return false;
    }*/
}
