using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class triggerDoorOpen : MonoBehaviour
{
    public GameObject openDoor;
    public GameObject closedDoor;
    //public bool froze;
    public playerMovement something;

    private bool opened = false;
    private float dur = 2f;
    private float timer;
    
    public float lerpSpeed;

    public Color curColor;
    private Color targetColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
       targetColor = new Color(1, 1, 1, 1);
        //opened = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      targetColor = new Color(1, 1, 1, 0);
    }

    /*private void Start()
    {
        timer = dur;
    }*/

    private void Update()
    {
        
        /*if (opened)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                
                something.froze = true;
            }
            else
            {
                transform.gameObject.SetActive(false);
                something.froze = false;
            }
            if(timer < 1f && timer > .5f)
            {
                timer -= Time.deltaTime;
                doorOpen();
            }
        }*/

        curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

        gameObject.GetComponent<TextMeshPro>().color = curColor;
        
    }


    
    public bool doorOpen()
    {
        closedDoor.gameObject.SetActive(false);
        openDoor.gameObject.SetActive(true);

        return true;
    }
}
