using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float distance = .8f;
    public float speed = 5;
    public float moveSpeed;
    private int dirx;
    private int diry;
    public Rigidbody2D rb;
    public Animator anim;
    public LayerMask boxmask;
    public Transform origin;
    GameObject box;

    public Vector2 moveDir;

    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveSpeed = Mathf.Clamp(moveDir.magnitude, 0f, 1f);

        if (moveDir != Vector2.zero)
        {
            anim.SetFloat("x", moveDir.x);
            anim.SetFloat("y", moveDir.y);
        }
        anim.SetFloat("speed", moveSpeed);

        grabber();
        //Debug.Log(moveDir);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
        //rb.velocity = moveDir * 5;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        //Debug.Log();
    }

    void grabber()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(origin.position, new Vector2(dirx, diry), distance, boxmask);
        if (hit.collider != null && hit.collider.gameObject.tag == "pushable" && Input.GetKey(KeyCode.Z))
        {
            box = hit.collider.gameObject;
            //box = hit.collider.gameObject;
            if (box != null)
            {
                box.GetComponent<FixedJoint2D>().enabled = true;
                box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            }
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            if (box != null)
            {
                box.GetComponent<FixedJoint2D>().enabled = false;
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //Vector2 dire = new Vector2(dirx, diry);
        if (moveDir != Vector2.zero)
        {
            if (moveDir.x >= 0.1f)
            {
                dirx = 1;
                diry = 0;
            }
            else if (moveDir.x <= -0.1f)
            {
                dirx = -1;
                diry = 0;
            }
            if (moveDir.y >= 0.1f)
            {
                dirx = 0;
                diry = 1;
            }
            else if (moveDir.y <= -0.1f)
            {
                dirx = 0;
                diry = -1;
            }
        }

        //Gizmos.DrawLine(origin.position, new Vector2(dirx, 0) + (Vector2)origin.position);
        Gizmos.DrawLine(origin.position, new Vector2(dirx, diry) + (Vector2)origin.position);
    }
}

    
