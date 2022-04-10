using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.SceneManagement;

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
                    tempAnswer = buttonL.block();
                    if (buttonL.block() == "A" || buttonL.block() == "B" || buttonL.block() == "C")
                        answer[i] = bllToStr(strToBlArray(buttonL.block()));
                    else
                        answer[i] = buttonL.block();
                }
            }
        answers(answer);
        }
    }
    
    public string bllToStr(bool x)
    {
        if (x)
            return "1";
        else
            return "0";
    }
    
    public bool strToBlArray(string x)
    {
        if (x == "A")
            if (bracelet._a)
                return true;
            else
                return false;
        if (x == "B")
            if (bracelet._b)
                return true;
            else
                return false;
        if (x == "C")
            if (bracelet._c)
                return true;
            else
                return false;
        else 
            return false;
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
        if (answer.Length <= 2)
        {
            if (answer.SequenceEqual(new string[2] {"!", "1"}))
                doorOpen();
        }
        else
            if (answer.SequenceEqual(new string[7] {answer[0], "->", answer[2], "&", answer[4], "->", "1"}) || answer.SequenceEqual(new string[7] {"1", "->", "0", "&", "1", "->", "0"}))
                doorOpen();
            else
                doorClose();
        
        
    }
}
