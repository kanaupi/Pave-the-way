using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject player;
    public LayerMask ladder;

    bool mf=false;
    bool mb = false;
    bool mu = false;
    bool stay = false;
    bool afterCliming = false;

    Rigidbody2D rb;

    public float speed = 0.5f;
    public int speedup = 1;
    bool buttonClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, 2,ladder);
        if (hitInfo.collider != null)
        {
            mu = true;
            stay = false;
            afterCliming = true;
        }
        if (hitInfo.collider == null && afterCliming) { 
            
            mu = false;
            mf = true;
            afterCliming = false;
        }
    }

    public void Moveforward()
    {
        player.transform.position += new Vector3(speed*speedup,0,0);
    }
    public void Moveback()
    {
        player.transform.position -= new Vector3(speed * speedup, 0,0);
    }
    public void Moveup()
    {
        player.transform.position += new Vector3(0, speed * speedup, 0);
        rb.gravityScale = 0;
    }
    public void GoButton()
    {
        mf = true;
        buttonClicked = true;
        
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
        if (buttonClicked&&coll.gameObject.tag == "turnleft")
        {
            mb = true;
            mf = false;
        }else if (buttonClicked&&coll.gameObject.tag == "block")
        {
            mf = true;
            mb = false;
        }
        else if (buttonClicked&&coll.gameObject.tag == "Thorns")
        {
            Retry();
        }
        else if (buttonClicked && coll.gameObject.tag == "Goal")
        {
            stay = false;
            Debug.Log("うん");
        }

    }
    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Goal")
        {
            stay = true;
        }
    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.tag != "turnleft")
        {
            stay = false;
        }
    }
    
}
