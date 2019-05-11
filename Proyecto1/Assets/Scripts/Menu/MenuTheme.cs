using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTheme : MonoBehaviour {

	void Awake()
	{
		GameObject audio = GameObject.FindGameObjectWithTag("Music");
		if(audio != this.gameObject && audio.GetComponent<AudioSource>().isPlaying) Destroy(this.gameObject);
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "ListOfLevels")
		Destroy(this.gameObject);
	}
}
