using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIManagerMenu : MonoBehaviour {
    
    public AudioClip buttonSound;
    public AudioMixer audioMixer;
    public GameObject menu, video;
    public KeyCode SkipVideoKey;

    private void Start()
    {
        menu.SetActive(false);
        if (GameManager.instance.GetIniVideoPlay()) Invoke("SeeMenu", 34f);
        else Invoke("SeeMenu", 0);
        Time.timeScale = 1f;
        print(GameManager.instance.GetIniVideoPlay());
    }
    
    private void Update()
    {
        if (Input.GetAxis("Submit")>0)
        {
            Invoke("SeeMenu", 0f);
        }
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
        GameManager.SetIniVideoPlay();
        video.SetActive(false);
        menu.SetActive(true);
        print(GameManager.instance.GetIniVideoPlay());
    }    
    public void PlaySoundButton(){
        AudioManager.instance.PlayClip(buttonSound);
    }
}
