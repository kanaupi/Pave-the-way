using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startscene : MonoBehaviour
{
    public AudioClip click;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void StartGame()
    {
        audioSource.PlayOneShot(click);
        SceneManager.LoadScene("StageSelect");
    }
}
