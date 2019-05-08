using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIManagerMenu : MonoBehaviour {
    
    public AudioClip buttonSound;
    public AudioMixer audioMixer;
    public GameObject menu;
    public KeyCode SkipVideoKey;

    private void Start()
    {
        //once = true;
        //Invoke("SeeMenu", 10);
        Time.timeScale = 1f;
    }
    
    private void Update()
    {
    }
    

    public void ChangeScene(string scene)
    {
        GameManager.instance.ChangeScene(scene);
    }

    //encontrar para salir
    public void ExitGame()
    {
        print("Has salido del juego");
        GameManager.instance.ExitGame();
    }
    void SeeMenu()
    {
        menu.SetActive(true);
    }    
    public void PlaySoundButton(){
        AudioManager.instance.PlayClip(buttonSound);
    }

}
