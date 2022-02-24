using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSpawner : MonoBehaviour
{
    public int size;
    public GameObject ObjectToSpawn;
    private GameObject[] buttons;

    private void Start()
    {
        buttons = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            buttons[i] = Instantiate(ObjectToSpawn, transform.position + new Vector3(i, 0, 0), transform.rotation);
            //Debug.Log(i);
        }
    }

    private void Update()
    {
        
        
    }
}