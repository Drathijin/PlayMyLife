using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIManagerEnding : MonoBehaviour {
    
    public GameObject menu, video;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameEnding()
    {
        menu.SetActive(false);
        video.SetActive(true);
        Invoke("GoToMenu", 34f);
    }

    public void GoToMenu()
    {
        GameManager.instance.ChangeScene("menu");
    }
}
