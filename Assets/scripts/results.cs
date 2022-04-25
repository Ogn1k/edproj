using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class results : MonoBehaviour
{

    public boolSO some;
    
    public GameObject text0;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    
    private float dur = 10f;
    private float timer;
    
    private void Start()
    {
        timer = dur;
        text0.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0);
        text1.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0);
        text2.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0);
        text3.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0);
    }

    public void isComplete(bool vari, GameObject text)
    {
        if (vari == true)
        {
            text.GetComponent<TextMeshProUGUI>().text = "LVL 1: НЕ ЗАКОНЧЕН";
        }
        else
        {
            text.GetComponent<TextMeshProUGUI>().text = "LVL 1: ЗАКОНЧЕН";
        }
            
    }
    
    // Update is called once per frame
    void Update()
    {
        isComplete(some._a, text1);
        isComplete(some._b, text2);
        isComplete(some._c, text3);
        
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                
            }

            if(timer < 2.5f && timer > 2f)
            {
                timer -= Time.deltaTime;
                text3.GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 1);
            }
            if(timer < 3.5f && timer > 3f)
            {
                timer -= Time.deltaTime;
                text2.GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 1);
            }
            if(timer < 4.5f && timer > 4f)
            {
                timer -= Time.deltaTime;
                text1.GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 1);
            }
            if(timer < 6.5f && timer > 6f)
            {
                timer -= Time.deltaTime;
                text0.GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 1);
            }
        

    }
}
