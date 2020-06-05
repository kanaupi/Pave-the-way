using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Action : MonoBehaviour
{
    public int pickaxeNumber;
    public int ladderNumber;
    public int blockNumber;
    public GameObject ladder;
    public GameObject createdladder;
    public GameObject block;
    public GameObject createdblock;
    public GameObject pickaxe;
    public Text pickaxeFigure;
    public Text ladderFigure;
    public Text blockFigure;

    bool canpickaxe=false;
    bool canladder = false;
    bool canblock=false;

    // Start is called before the first frame update
    void Start()
    {
        if (blockNumber == 0)
        {
            blockFigure.gameObject.SetActive(false);
        }
        if (pickaxeNumber == 0)
        {
            pickaxeFigure.gameObject.SetActive(false);
        }
        if (ladderNumber == 0)
        {
            ladderFigure.gameObject.SetActive(false);
        }
        pickaxeFigure.text = "×" + pickaxeNumber.ToString();
        ladderFigure.text = "×" + ladderNumber.ToString();
        blockFigure.text = "×" + blockNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
        //Rayの長さ
        float maxDistance = 10;

        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);
        if (hit.collider != null)
        {
            if (Input.GetMouseButton(0) && hit.collider.tag == "pickaxe")
            {
                if (pickaxeNumber != 0)
                {
                    hit.collider.GetComponent<Renderer>().material.color = Color.black;
                    canpickaxe = true;
                    canladder = false;
                    canblock = false;
                }
            }
            else if (Input.GetMouseButtonDown(0) && hit.collider.tag == "ladder")
            {
                if (ladderNumber != 0)
                {
                    hit.collider.GetComponent<Renderer>().material.color = Color.black;
                    canpickaxe = false;
                    canladder = true;
                    canblock = false;
                }
            }
            else if (Input.GetMouseButtonDown(0) && hit.collider.tag == "block")
            {
                if (canpickaxe==false&&blockNumber != 0)
                {
                    hit.collider.GetComponent<Renderer>().material.color = Color.black;
                    canpickaxe = false;
                    canladder = false;
                    canblock = true;
                }
            }

        }
        
        if (canpickaxe&& pickaxeNumber > 0)
        {
            Destroy();
        }
        if (canladder && ladderNumber > 0)
        {
            CreateLadder();
        }
        if (canblock && blockNumber > 0)
        {
            CreateBlock();
        }
    }

    public void Destroy()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float maxDistance = 10;

        RaycastHit2D hit2 = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);
        if(hit2.collider !=null && Input.GetMouseButton(0))
        {
            if (hit2.collider.tag == "block") {
                Destroy(hit2.collider.gameObject);
                pickaxeNumber--;
                pickaxeFigure.text = "×" + pickaxeNumber.ToString();
                pickaxe.GetComponent<Renderer>().material.color = Color.white;
                canpickaxe = false;
            }

        }
        
    }
    public void CreateLadder()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float maxDistance = 10;
        RaycastHit2D hit3 = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);
        if (hit3.collider == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(createdladder, new Vector3((int)Math.Round(vector.x), (int)Math.Round(vector.y), 0), Quaternion.identity);
                ladderNumber--;
                ladderFigure.text = "×" + ladderNumber.ToString();
                ladder.GetComponent<Renderer>().material.color = Color.white;
                canladder = false;
            }

        }
    }
    public void CreateBlock()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float maxDistance = 10;
        RaycastHit2D hit3 = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);
        if (hit3.collider == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(createdblock, new Vector3((int)Math.Round(vector.x), (int)Math.Round(vector.y), 0), Quaternion.identity);
                blockNumber--;
                blockFigure.text = "×" + blockNumber.ToString();
                block.GetComponent<Renderer>().material.color = Color.white;
                canblock = false;
            }

        }
    }

}