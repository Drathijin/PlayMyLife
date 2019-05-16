using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTheme : MonoBehaviour {

	void Awake()
	{
		GameObject audio = GameObject.FindGameObjectWithTag("Music");
		if(audio.GetComponent<MusicClass>()!=null)Destroy(audio);
        if (audio != this.gameObject && audio.GetComponent<AudioSource>().isPlaying && audio.name ==
        "MainMenuTheme") Destroy(this.gameObject);
		
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Use this for initialization
	void OnEnable () {
        PlayThis();
    }

    private void PlayThis()
    {
        this.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update () {
		if(SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "ListOfLevels")
		Destroy(this.gameObject);
	}
}
