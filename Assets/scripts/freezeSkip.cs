using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class freezeSkip : MonoBehaviour
{
    public string scene;
    public boolSO some;
   public void onButtonPress()
   {
       SceneManager.LoadScene(scene);
       if (SceneManager.GetActiveScene().name == "lvl1")
           some._a = true;
       if (SceneManager.GetActiveScene().name == "lvl2")
           some._b = true;
       if (SceneManager.GetActiveScene().name == "lvl3")
           some._c = true;
   }
}
