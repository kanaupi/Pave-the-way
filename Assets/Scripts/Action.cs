using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Action : MonoBehaviour
{
    public int pickaxeNumber;
    public int ladderNumber;
    public GameObject ladder;
    bool canpickaxe=false;
    bool canladder = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(canladder);
        //Rayの長さ
        float maxDistance = 10;

        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "pickaxe")
            {
                if (Input.GetMouseButton(0) && pickaxeNumber != 0)
                {
                    hit.collider.GetComponent<Renderer>().material.color = Color.black;
                    canpickaxe = true;
                    canladder = false;
                }
            }
            else if (hit.collider.tag == "ladder")
            {
                if (Input.GetMouseButtonDown(0) && ladderNumber != 0)
                {
                    hit.collider.GetComponent<Renderer>().material.color = Color.black;
                    canpickaxe = false;
                    canladder = true;
                }
            }
        }
        
        if (canpickaxe)
        {
            Destroy();
        }
        if (canladder)
        {
            CreateLadder();
        }
    }

    public void Destroy()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float maxDistance = 10;

        RaycastHit2D hit2 = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);
        if(hit2.collider.tag == "block" && Input.GetMouseButton(0))
        {
            Destroy(hit2.collider.gameObject);

        }
        
    }
    public void CreateLadder()
    {
        Debug.Log("うん");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float maxDistance = 10;
        RaycastHit2D hit3 = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);
        if (hit3.collider == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(ladder, new Vector3((int)Math.Round(vector.x), (int)Math.Round(vector.y), 0), Quaternion.identity);
            }
            
        }
         
    }
}