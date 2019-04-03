using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {

    public Sounds[] sounds;

    float audioVolume=1;


    private void Awake()
    {
        foreach (Sounds s in sounds) 
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            //el volumen es el que se ha marcado en el menú
            s.source.volume = audioVolume;
            //el pitch tiene que ser 1; si no, suena distorsionado
            s.source.pitch = 1;
        }
    }

    void Start()
    {
        GameManager.instance.SetAudioManager(this);
    }

    //guardamos el volumen del menú
    public void SaveVolume(float volume)
    {
        audioVolume = volume;
    }

    //reproduce la pista con el nombre name
    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
