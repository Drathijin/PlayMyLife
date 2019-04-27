using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public AudioSetting[] audioSettings;
    public AudioMixer masterMixer;
    private AudioObject currentClip = null;
    

    //asignamos los valores del editor a las variables con las que vamos a trabajar
    private void Start()
    {

        for (int i=0; i< audioSettings.Length; i++)
        {

            audioSettings[i].SetAudioManager(this);
            audioSettings[i].Initialize();
        }
    }

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

    public void SetCurrentClip(AudioObject AO)
    {
        if(currentClip != null) currentClip.KillMe();
        currentClip = AO;
        currentClip.Play();
    }

    public void PlayClip(GameObject gO)
    {
        AudioSource audio = gO.GetComponent<AudioSource>();
        audio.Play();
        Destroy(gO, audio.clip.length);
    }
    
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

