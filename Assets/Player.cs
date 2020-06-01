using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject player;
    public GameObject breakableBlock;
    public GameObject turnleft;

    bool mf=false;
    bool mb = false;
    bool stay = false;

    public float speed = 0.5f;
    bool buttonClicked = false;
    // Start is called before the first frame update
    void Start()
    { 
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
        if (stay == false)
        {
            mf = false;
            mb = false;
        }
    }

    public void Moveforward()
    {
        player.transform.position += new Vector3(speed,0,0);
    }
    public void Moveback()
    {
        player.transform.position -= new Vector3(speed,0,0);
    }
    public void GoButton()
    {
        mf = true;
        buttonClicked = true;
        
    }
    
    private void OnCollisionEnter2D(Collision2D coll)
    {
        stay = true;
        if (coll.gameObject.tag == "turnleft")
        {
            mb = true;
            mf = false;
        }else if (buttonClicked && coll.gameObject.tag == "BreakableBlock")
        {
            mf = true;
            mb = false;
        }
    }
    private void OnCollisionStay2D(Collision2D coll)
    {
        stay = true;
        
    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.tag != "turnleft")
        stay = false;
    }


}
