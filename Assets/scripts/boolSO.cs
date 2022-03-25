using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class boolSO : ScriptableObject
{
    [SerializeField]
    private bool _value;

    public bool value
    {
        get { return _value; }
        set { _value = value; }
    }
}
