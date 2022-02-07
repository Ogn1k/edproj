using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variableScript : MonoBehaviour
{
    public Transform origin;
    public LayerMask boxmask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void lineStacker()
    {
        RaycastHit2D hit = Physics2D.Raycast(origin.position, new Vector2(-1, 0), 1, boxmask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(origin.position, new Vector2(-1, 0) + (Vector2)origin.position);
    }
}