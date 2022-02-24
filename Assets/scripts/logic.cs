using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class logic : MonoBehaviour
{
    private string answer = "";
    private GameObject[] buttons;
    public GameObject spawner;
    public GameObject cd;
    public GameObject od;

    public void Start()
    {
        
        buttonSpawner temp = spawner.GetComponent<buttonSpawner>();
        buttons = new GameObject[temp.size];
        //Debug.Log(temp.size);

        od.gameObject.SetActive(false);

    }

    public void Update()
    {
        buttons = GameObject.FindGameObjectsWithTag("button");
        for (int i = 0; i < buttons.Length; i++)
        {
            buttonScript temp1 = buttons[i].GetComponent<buttonScript>();
            if (temp1.block() != null)
            { 
                if(!answer.Contains(temp1.block()) & temp1.block() == "!" )
                    answer += temp1.block();
                if (!answer.Contains(temp1.block()) & temp1.block() == "A")
                    answer += temp1.block();
            }
            //create array that fills with buttons
            //then for every button collect block value
            //compare string value with every answer
            //(answer == "!A") { doorOpen(); }
        }
        Debug.Log(answer);
        answers(answer);
    }

    public bool doorOpen()
    {
            cd.gameObject.SetActive(false);
            od.gameObject.SetActive(true);

        return true;
    }
    public bool doorClose()
    {
            cd.gameObject.SetActive(true);
            od.gameObject.SetActive(false);

        return false;
    }
    public void answers(string answer)
    {
        if (answer == null)
        {
            doorClose();
            //return false;
        }
        if (answer == "!A")
        {
            doorOpen();
        }
    }
}
