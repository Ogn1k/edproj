using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class freezeSkip : MonoBehaviour
{
    public string scene;
   public void onButtonPress()
   {
       SceneManager.LoadScene(scene);
   }
}