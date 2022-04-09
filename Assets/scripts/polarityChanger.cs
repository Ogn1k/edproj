using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polarityChanger : buttonScript
{
    public boolSO bracelet;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (obj != null)
        {
            if (obj.CompareTag("A"))
                bracelet._a = !bracelet._a;
            if (obj.CompareTag("B"))
                bracelet._b = !bracelet._b;
            if (obj.CompareTag("C"))
                bracelet._c = !bracelet._c;
        }
    }

    public override string block()
    {
        return "";
    }
}
