using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


public class logic : MonoBehaviour
{
    private string answer = "";
    private GameObject[] buttons;
    public GameObject spawner;
    public GameObject cd;
    public GameObject od;
    string tempAnswer = null;
    buttonSpawner buttonspawner;

    public void Start()
    {

        buttonspawner = spawner.GetComponent<buttonSpawner>();
        buttons = new GameObject[buttonspawner.size];
        //Debug.Log(temp.size);

        od.gameObject.SetActive(false);
        
        

    }

    public void Update()
    {
        
        if(buttonspawner.triggerEnterReturn())
        {
            buttons = GameObject.FindGameObjectsWithTag("button");
            for (int i = 0; i < buttons.Length; i++)
            {
                buttonScript buttonL = buttons[i].GetComponent<buttonScript>();
                if (buttonL.block() != null)
                {
                    if (!answer.Contains(buttonL.block()))
                    {
                        tempAnswer = buttonL.block();
                        answer += buttonL.block();
                    }
                }
                answers(answer);
            }
        }
        if(buttonspawner.triggerExitReturn())
        {
            if(tempAnswer != null)
                answer = answer.Replace(tempAnswer, "");
            answers(answer);
        }
        //Debug.Log(answer);
        //create array that fills with buttons
        //then for every button collect block value
        //compare string value with every answer
        //(answer == "!A") { doorOpen(); }


        

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
        
           
          
        if (answer == "!A")
            doorOpen();
        else
            doorClose();
        
    }
}
