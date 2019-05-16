using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIManagerEnding : MonoBehaviour {
    
    public GameObject menu, video;
    bool skipable = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Submit") > 0 && skipable)
        {
            skipable = false;
            Invoke("GoToMenu", 0f);
        }
    }

    public void GameEnding()
    {
        GameManager.instance.Play();
        menu.SetActive(false);
        video.SetActive(true);
        Invoke("GoToMenu", 34f);
    }

    public void GoToMenu()
    {
        GameManager.instance.ChangeScene("Menu");
    }

    public void AllowSkip()
    {
        Invoke("ChangeSkipable", 0.8f);
    }

    void ChangeSkipable()
    {
        skipable = true;
    }
}
