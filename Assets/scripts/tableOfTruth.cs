using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tableOfTruth : MonoBehaviour
{
    public GameObject bools;
    public GameObject cd;
    public GameObject od;
    bool[,] table = new bool[,] {  
        { false, false, false, false }, 
        { false, false, false, false }, 
        { false, false, false, false },
        { false, false, false, false }
    };
    
    

    // Update is called once per frame
    void Update()
    {
        if( bools != null )
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    table[i, j] = strToBl( bools.transform.GetChild(i).transform.GetChild(j).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().GetParsedText());
                    
                }
            }
            correctAnswer(table);
            
        }
    }
    
    public string bllToStr(bool x)
    {
        if (x)
            return "1";
        else
            return "0";
    }
    
    public bool strToBl(string x)
    {
        if (x == "1")
            return true;
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

    public bool equalMathix(bool[,] m1, bool[,] m2)
    {
        bool result = true;
        if (m1.GetLength(0) != m2.GetLength(0) || m1.GetLength(1) != m2.GetLength(1))
        {
            throw new Exception("illegal mathix dimensions");
            result = false;
        }
        else
        {
            for (int i = 0; i < m1.GetLength(0) && result; i++)
            {
                for (int j = 0; j < m1.GetLength(0) && result; j++)
                {
                    if (m1[i, j] != m2[i, j])
                    {
                        result = false;
                    }
                }
            }
        }
            
        return result;
    }

    private void correctAnswer(bool[,] answer)
    {
        bool[,] temp = new bool[,]
        {
            {false, false, true, true},
            {false, true, true, false},
            {true, false, false, true},
            {true, true, false, true}
            //{ false, false, false, false }, 
            //{ false, false, false, false }, 
            //{ false, false, false, false },
            //{ false, false, false, false }
        };
        bool result = equalMathix(answer, temp);
        if (result)
        {
            doorOpen();
        }
        else
            doorClose();
    } 
}
