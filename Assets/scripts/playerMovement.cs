using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public float distance = 1f;
    public float speed = 5;
    public float moveSpeed;
    private int dirx;
    private int diry;
    public Rigidbody2D rb;
    public Animator anim;
    public LayerMask boxmask;
    public Transform origin;
    GameObject box;
    public boolSO braceletPick;
    public Canvas tableT;
    public Canvas windowUI;
    public Canvas ui;

    public triggerDoorOpen oneFunk;

    public Vector2 moveDir;

    public bool froze = false;

    private void OnApplicationQuit()
    {
        braceletPick.value = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ui != null)
        {
            if (braceletPick.value)
                ui.gameObject.SetActive(true);
            else
                ui.gameObject.SetActive(false);
            gameInterface();
        }

        if (canPlayerMove())
        {
            
                moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                moveSpeed = Mathf.Clamp(moveDir.magnitude, 0f, 1f);
                grabber();
                if (moveDir != Vector2.zero)
                {
                    anim.SetFloat("x", moveDir.x);
                    anim.SetFloat("y", moveDir.y);
                }
                anim.SetFloat("speed", moveSpeed);
            
            
            
        }
        else
        {
            moveDir = Vector2.zero;
            moveSpeed = 0;
        }
       
        
    }

    private bool canPlayerMove()
    {
        if (windowUI != null )
            if(windowUI.gameObject.activeSelf)
                return false;
        if (tableT != null)
            if(tableT.gameObject.activeSelf)
                return false;
        if (froze)
            return false;
        
        
        return true;

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
        //rb.velocity = moveDir * 5;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    public void grabber()
    {
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
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(origin.position, new Vector2(dirx, diry), distance, boxmask);
        if (hit.collider != null )
        {
            box = hit.collider.gameObject;
            if (objectInteraction("pushable", hit.collider.gameObject))
            {
                if (box != null)
                {
                    box.GetComponent<FixedJoint2D>().enabled = true;
                    box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
                }
            }
            if (objectInteraction("terminal", hit.collider.gameObject))
            {
                tableT.gameObject.SetActive(true);
                
            }
            if (objectInteraction("window", hit.collider.gameObject))
            {
                windowUI.gameObject.SetActive(true);
                
            }
            if (objectInteraction("door", hit.collider.gameObject))
            {
                oneFunk.doorOpen();
                Debug.Log(1);
            }
            if (objectInteraction("plate", hit.collider.gameObject))
            {
                tableT.gameObject.SetActive(true);
            }

        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            if (box != null)
            {
                if(box.GetComponent<FixedJoint2D>())
                    box.GetComponent<FixedJoint2D>().enabled = false;
            }
        }

    }

    public bool objectInteraction(string tag, GameObject box)
    {
        if (box.CompareTag(tag) && Input.GetKeyDown(KeyCode.Z))
        {
            return true;
        }

        return false;
    }

    public string boolToString(bool x)
    {
        if (x)
            return "1";
        else
            return "0";
    }
    
    public void gameInterface()
    {
        ui.gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = boolToString(braceletPick._a);
        if(ui.gameObject.transform.childCount >= 2)
            ui.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = boolToString(braceletPick._b);
        if(ui.gameObject.transform.childCount >= 3)
            ui.gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = boolToString(braceletPick._c);
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

        //Gizmos.DrawLine(hit);
        Gizmos.DrawLine(origin.position, new Vector2(dirx, diry) + (Vector2)origin.position);
    }
}

    
