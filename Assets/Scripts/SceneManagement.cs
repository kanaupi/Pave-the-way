using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    public String selectedStage;
    public GameObject Sceneplayer;
    public Player script;
    public int yourscore=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yourscore = script.Getscore();
        if (yourscore != 0)
        {
            Sceneplayer.transform.position = new Vector3(-9 + yourscore * 4.5f, -3, 0);
        }
    }
    public void StageSelect()
    {
        SceneManager.LoadScene("stage" + selectedStage);
    }
    public void stage11()
    {
        selectedStage = "1-1";
        StageSelect();
    }
    public void stage12()
    {
        selectedStage = "1-2";
        StageSelect();
    }
}
