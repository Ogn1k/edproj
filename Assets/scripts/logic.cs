using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public static class Extensions
{
    public static bool find<T>(this T[] array, T target) {
        return array.Contains(target);
    }
}
public class logic : MonoBehaviour
{
    private string[] answer;
    private GameObject[] buttons;
    public GameObject spawner;
    public GameObject cd;
    public GameObject od;
    string tempAnswer = null;
    buttonSpawner buttonspawner;

    public boolSO bracelet;
    
    public void Start()
    {

        if (spawner != null)
        {
            
        
        buttonspawner = spawner.GetComponent<buttonSpawner>();
        buttons = new GameObject[buttonspawner.size];
        //Debug.Log(temp.size);
        answer = new string[buttons.Length];
        od.gameObject.SetActive(false);
        
        
        buttons = GameObject.FindGameObjectsWithTag("button");
    }
    }
    public void Update()
    {
        if (spawner != null)
        {
            
        
        for (int i = 0; i < buttons.Length; i++)
        {
            if(buttons[i].GetComponent<buttonScript>() == null)
                throw new Exception("no button script component in buttons");
            buttonScript buttonL = buttons[i].GetComponent<buttonScript>();
            if (buttonspawner.triggerEnterReturn())
            {
                /*if (buttonL.block() == null)
                {
                }*/
                tempAnswer = buttonL.block();
                answer[i] = buttonL.block();
            }

            /*if(buttonspawner.triggerExitReturn())
            {
                if (tempAnswer != null && tempAnswer == answer[i])
                {
                    tempAnswer = null;
                    answer[i] = null;
                }
            }*/
            
        }
        answers(answer);
        //Debug.Log(answer);
        //create array that fills with buttons
        //then for every button collect block value
        //compare string value with every answer
        //(answer == "!A") { doorOpen(); }


        
        }
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
    
    
    
    public void answers(string[] answer)
    {
        
        if (answer.SequenceEqual(new string[2] {"!", "A"}) & !bracelet._a)
            doorOpen();
        else
            doorClose();
        
    }
}
