using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIManagerMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public GameObject menu;

    private void Start()
    {
        Invoke("SeeMenu", 10);
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

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    void SeeMenu()
    {
        menu.SetActive(true);
    }

}
