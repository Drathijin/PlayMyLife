using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {

    public AudioSetting[] audioSettings;
    public AudioMixer masterMixer;
    private AudioObject currentClip = null;
    private AudioSource defaultPlayer = null;
    static public AudioManager instance = null;

    private void Awake()
    {
        if(instance==null)instance=this;
        else Destroy(this.gameObject);
    }
    

    //asignamos los valores del editor a las variables con las que vamos a trabajar
    private void Start()
    {

        for (int i=0; i< audioSettings.Length; i++)
        {
            audioSettings[i].SetAudioManager(this);
            audioSettings[i].Initialize();
        }
        try{
            defaultPlayer = this.GetComponent<AudioSource>();
        }catch{print("no se encuentra audiosource");}
    }

#region Cambiar volumen de las pistas
    public void SetMusicVolume(float value)
    {
        int i = 0;
        while(audioSettings[i].parameterName!= "MusicVol")
        {
            i++;
        }
        audioSettings[i].SetVolume(value);
    }

    public void SetSFXVolume(float value)
    {
        int i = 0;
        while (audioSettings[i].parameterName != "SFXVol")
        {
            i++;
        }
        audioSettings[i].SetVolume(value);
    }
#endregion
#region Clips que se interrumpen (Posibles pistas de diálogo)
    public void SetCurrentClip(AudioObject AO)
    {
        if(currentClip != null) currentClip.KillMe();
        currentClip = AO;
        currentClip.Play();
    }
#endregion
#region Clips que no se interrumpen 
    public void PlayClip(GameObject gO)
    {
        AudioSource audio = gO.GetComponent<AudioSource>();
        audio.Play();
        Destroy(gO, audio.clip.length);
    }
    public void PlayClip(AudioSource aS)
    {
        aS.Play();
        Destroy(aS.gameObject, aS.clip.length);
    }
    public void PlayClip(AudioClip clip)
    {
        defaultPlayer.clip = clip;
        defaultPlayer.Play();
        Invoke("ResetAudioClip", clip.length);
    }

    private void ResetAudioClip()
    {
        defaultPlayer.clip = null;
    }
    #endregion
}

[System.Serializable]
public class AudioSetting
{
    
    public Slider slider;
    public string parameterName;
    AudioManager theAudioManager;
    public void SetAudioManager(AudioManager AudioManager)
    {
        theAudioManager = AudioManager;
        
    }

    /// <summary>
    /// Inicializamos los valores para el audioMixer
    /// </summary>
    public void Initialize()
    {
        //el slider se pone al valor inicial del parámetro
        slider.value = PlayerPrefs.GetFloat(parameterName);
    }

    /// <summary>
    /// Cambiamos el valor del volumen en el audiomixer.
    /// También se guarda el valor en las preferencias del jugador. El valor se carga en la siguiente ejecución.
    /// </summary>
    public void SetVolume(float value)
    {
        theAudioManager.masterMixer.SetFloat(parameterName, value);
        PlayerPrefs.SetFloat(parameterName, value);
    }
}

