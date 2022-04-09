using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class boolChangeButtonPress : MonoBehaviour
{
    // Start is called before the first frame update
    private bool textBool = false;
    
    public string bllToStr(bool x)
    {
        if (x)
            return "1";
        else
            return "0";
    }

    public void onButtonPress()
    {
        textBool = !textBool;
        transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = bllToStr(textBool);
    }
    
}
