using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class braceletScript : MonoBehaviour
{
    public boolSO braceletPick;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        braceletPick.value = true;
        transform.gameObject.SetActive(false);
    }
}
