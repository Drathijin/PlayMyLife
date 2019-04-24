using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIManagerMenu : MonoBehaviour {
    
    public AudioMixer audioMixer;
    public GameObject menu;
    public KeyCode SkipVideoKey;
    //private bool once;
    //después de diez segundos, mostrará el menú
    private void Start()
    {
        //once = true;
        //Invoke("SeeMenu", 10);
    }
    
    private void Update()
    {
        //si se pulsa la tecla esc, se termina el vídeo y sale el menú directamente.
        /*if (Input.GetKeyDown(SkipVideoKey) && once)
        {        
            CancelInvoke("SeeMenu");
            //falta añadir la imagen que sustituya al vídeo. 
            menu.SetActive(true);
            once = false;

        }
        */
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
    /*
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        GameManager.instance.SetVolume(volume);        
    }
    */
    void SeeMenu()
    {
        menu.SetActive(true);
    }

}
