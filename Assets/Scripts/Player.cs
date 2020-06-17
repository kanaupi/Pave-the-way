using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    public GameObject player;
    public LayerMask ladder;
    

    bool mf=false;
    bool mb = false;
    bool mu = false;
    bool stay = true;
    bool afterCliming = false;
    bool oldmf=true;
    bool oldmb=false;
    bool iscalledonce = false;
    bool goaled = false;
    bool firstclime=true;

    Rigidbody2D rb;

    public float speed = 0.5f;
    public int speedup = 1;
    bool buttonClicked = false;
    public static int yourscore = 0;

    SpriteRenderer MainSpriteRenderer;
    public Sprite sleep;
    public Sprite gameover;
    public Sprite clime;
    public Sprite stand;
    public Sprite right;
    public Sprite left;
    public Sprite smile;

    public AudioClip death;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (buttonClicked == false)
        {
            MainSpriteRenderer.sprite = sleep;
        }
        if (mf)
        {
            Moveforward();
        }
        if (mb)
        {
            Moveback();
        }
        if (mu)
        {
            Moveup();
        }else
        {
            rb.gravityScale = 0.1f * speedup;
        }
        if (stay == false)
        {
            mf = false;
            mb = false;
        }
        if (mu == false && mb == false && mf == false&&buttonClicked&&!goaled)
        {
            MainSpriteRenderer.sprite = stand;
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, 2, ladder);
        if (hitInfo.collider != null)
        {
            if (firstclime)
            {
                mu = true;
                stay = false;
                afterCliming = true;
            }
        }
        if (hitInfo.collider == null && afterCliming) {
            iscalledonce = false;
            firstclime = false;
            mu = false;
            if (oldmf)
            {
                
                transform.position += new Vector3(0.2f, 0, 0);
            }
            else
            {
                transform.position += new Vector3(-0.2f, 0, 0);
            }
            mf = oldmf;
            mb = oldmb;
            afterCliming = false;
            
        }
    }

    public void Moveforward()
    {
        player.transform.position += new Vector3(speed*speedup,0,0);
        MainSpriteRenderer.sprite = right;
    }
    public void Moveback()
    {
        player.transform.position -= new Vector3(speed * speedup, 0,0);
        MainSpriteRenderer.sprite = left;
    }
    public void Moveup()
    {
        player.transform.position += new Vector3(0, speed * speedup, 0);
        rb.gravityScale = 0;
        MainSpriteRenderer.sprite = clime;
    }
    public void GoButton()
    {
        mf = true;
        buttonClicked = true;
        speedup = 1;
        
    }
    public void SpeedUpButton()
    {
        speedup = 2;
        

    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        stay = true;
        firstclime = true;
        iscalledonce = false;
        if (buttonClicked && (coll.gameObject.tag == "block" || coll.gameObject.tag == "sand"))
        {
            if ((int)Math.Round(transform.position.y)==coll.transform.position.y)
            {
                mf = !oldmf;
                mb = !oldmb;
                oldmf = mf;
                oldmb = mb;
            }
            else
            {
                mf = oldmf;
                mb = oldmb;
            }
            
        }
        
        else if (buttonClicked&&coll.gameObject.tag == "Thorns")
        {
            MainSpriteRenderer.sprite = gameover;
            audioSource.PlayOneShot(death);
            Retry();
        }
        else if (buttonClicked && coll.gameObject.tag == "Goal")
        {
            MainSpriteRenderer.sprite = smile;
            goaled = true;
            stay = false;
            if (SceneManager.GetActiveScene().name == "stage1-1")
            {
                yourscore = 1;
            }
            else if (SceneManager.GetActiveScene().name == "stage1-2")
            {
                yourscore = 2;
            }
            else if (SceneManager.GetActiveScene().name == "stage1-3")
            {
                yourscore = 3;
            }
            else if (SceneManager.GetActiveScene().name == "stage1-4")
            {
                yourscore = 4;
            }
            else if (SceneManager.GetActiveScene().name == "stage1-5")
            {
                yourscore = 5;
            }
            Sleep();
            
            SceneManager.LoadScene("StageSelect");
        }

    }
    private void OnCollisionStay2D(Collision2D coll)
    {
        if (buttonClicked&&coll.gameObject.tag != "Goal")
        {

            stay = true;
            mf = oldmf;
            mb = oldmb;
        }
        

    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        mf = oldmf;
        mb = oldmb;
        stay = false;
        if (buttonClicked && coll.gameObject.tag == "sand")
        {
            if ((int)Math.Round(transform.position.y)>coll.transform.position.y)
            {
                Destroy(coll.gameObject);
            }
        }
    }
    
    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(3);  //3秒待つ
        
    }
    public int Getscore()
    {
        return yourscore;
    }

    
}
