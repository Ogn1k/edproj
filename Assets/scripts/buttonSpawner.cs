using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSpawner : MonoBehaviour
{
    public int size = 0;
    public GameObject ObjectToSpawn;
    private GameObject[] buttons;
    public bool vertical = false;
    private bool onTriggerEnter = false;
    private bool onTriggerExit = false;

    private void Start()
    {
        buttons = new GameObject[size];
        if (vertical)
        {
            for (int i = 0; i < size; i++)
            {
                buttons[i] = Instantiate(ObjectToSpawn, transform.position + new Vector3(0, i, 0), transform.rotation);
            }
        }
        else
        {
            for (int i = 0; i < size; i++)
            {
                buttons[i] = Instantiate(ObjectToSpawn, transform.position + new Vector3(i, 0, 0), transform.rotation);
            }
        }
        
        transform.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(size, 1);
        transform.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.5f, 0);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("button"))
            onTriggerEnter = false;
        else
            onTriggerEnter = true;
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("button"))
            onTriggerExit = false;
        else
            onTriggerExit = true;
    }

    public bool triggerExitReturn()
    {
        if(onTriggerExit)
            return true;
        return false;
    }
    
    public bool triggerEnterReturn()
    {
        if(onTriggerEnter)
            return true;
        return false;
    }
    private void Update()
    {
        
        
    }
}