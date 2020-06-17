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
    public int sandNumber;
    public GameObject ladder;
    public GameObject createdladder;
    public GameObject block;
    public GameObject createdblock;
    public GameObject pickaxe;
    public GameObject sand;
    public GameObject createdsand;
    public Text pickaxeFigure;
    public Text ladderFigure;
    public Text blockFigure;
    public Text sandFigure;

    bool canpickaxe=false;
    bool canladder = false;
    bool canblock=false;
    bool cansand = false;

    public AudioClip click;
    public AudioClip spawn;
    public AudioClip delete;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

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
        if (sandNumber == 0)
        {
            sandFigure.gameObject.SetActive(false);
        }

        pickaxeFigure.text = "×" + pickaxeNumber.ToString();
        ladderFigure.text = "×" + ladderNumber.ToString();
        blockFigure.text = "×" + blockNumber.ToString();
        sandFigure.text = "×" + sandNumber.ToString();
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
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject == pickaxe)
            {
                if (pickaxeNumber != 0)
                {
                    audioSource.PlayOneShot(click);
                    canpickaxe = true;
                    canladder = false;
                    canblock = false;
                    cansand = false;
                }
            }
            else if (Input.GetMouseButtonDown(0) && hit.collider.gameObject ==ladder)
            {
                if (ladderNumber != 0)
                {
                    audioSource.PlayOneShot(click);
                    canpickaxe = false;
                    canladder = true;
                    canblock = false;
                    cansand = false;
                }
            }
            else if (Input.GetMouseButtonDown(0) && hit.collider.gameObject == block)
            {
                if (blockNumber != 0)
                {
                    audioSource.PlayOneShot(click);
                    canpickaxe = false;
                    canladder = false;
                    canblock = true;
                    cansand = false;
                }
            }
            else if (Input.GetMouseButtonDown(0) && hit.collider.gameObject == sand)
            {
                if ( sandNumber != 0)
                {
                    audioSource.PlayOneShot(click);
                    canladder = false;
                    canblock = false;
                    cansand = true;
                }
            }

        }
        
        if (canpickaxe&& pickaxeNumber > 0)
        {
            pickaxe.GetComponent<Renderer>().material.color = Color.black;
            ladder.GetComponent<Renderer>().material.color = Color.white;
            block.GetComponent<Renderer>().material.color = Color.white;
            sand.GetComponent<Renderer>().material.color = Color.white;
            Destroy();
        }
        if (canladder && ladderNumber > 0)
        {
            pickaxe.GetComponent<Renderer>().material.color = Color.white;
            ladder.GetComponent<Renderer>().material.color = Color.black;
            block.GetComponent<Renderer>().material.color = Color.white;
            sand.GetComponent<Renderer>().material.color = Color.white;
            CreateLadder();
        }
        if (canblock && blockNumber > 0)
        {
            pickaxe.GetComponent<Renderer>().material.color = Color.white;
            ladder.GetComponent<Renderer>().material.color = Color.white;
            block.GetComponent<Renderer>().material.color = Color.black;
            sand.GetComponent<Renderer>().material.color = Color.white;
            CreateBlock();
        }
        if (cansand && sandNumber > 0)
        {
            pickaxe.GetComponent<Renderer>().material.color = Color.white;
            ladder.GetComponent<Renderer>().material.color = Color.white;
            block.GetComponent<Renderer>().material.color = Color.white;
            sand.GetComponent<Renderer>().material.color = Color.black;
            CreateSand();
        }
    }

    public void Destroy()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float maxDistance = 10;

        RaycastHit2D hit2 = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);
        if(hit2.collider !=null && Input.GetMouseButton(0))
        {
            if (hit2.collider.tag == "block"&&hit2.collider.gameObject!=block.gameObject) {
                Destroy(hit2.collider.gameObject);
                audioSource.PlayOneShot(delete);
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
                audioSource.PlayOneShot(spawn);
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
                audioSource.PlayOneShot(spawn);
                blockNumber--;
                blockFigure.text = "×" + blockNumber.ToString();
                block.GetComponent<Renderer>().material.color = Color.white;
                canblock = false;
            }

        }
    }
    public void CreateSand()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float maxDistance = 10;
        RaycastHit2D hit4 = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);
        if (hit4.collider == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(createdsand, new Vector3((int)Math.Round(vector.x), (int)Math.Round(vector.y), 0), Quaternion.identity);
                audioSource.PlayOneShot(spawn);
                sandNumber--;
                sandFigure.text = "×" + sandNumber.ToString();
                sand.GetComponent<Renderer>().material.color = Color.white;
                cansand = false;
            }

        }
    }

}