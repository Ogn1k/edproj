using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class general
{

    public bool doorOpen(Transform cd, Transform od)
    {

            cd.gameObject.SetActive(false);

            od.gameObject.SetActive(true);


        return true;
    }
    public bool doorClose(Transform cd, Transform od)
    {

            cd.gameObject.SetActive(true);

            od.gameObject.SetActive(false);

        return false;
    }
}
