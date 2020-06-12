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
        if (yourscore >= 0)
        {
            selectedStage = "1-1";
            StageSelect();
        }
        
    }
    public void stage12()
    {
        if (yourscore > 1)
        {
            selectedStage = "1-2";
            StageSelect();
        }
        
    }
    public void stage13()
    {
        if (yourscore > 2)
        {
            selectedStage = "1-3";
            StageSelect();
        }
    }
    public void stage14()
    {
        if (yourscore > 3)
        {
            selectedStage = "1-4";
            StageSelect();
        }
    }
    public void stage15()
    {
        if (yourscore > 4)
        {
            selectedStage = "1-5";
            StageSelect();
        }
    }
}
