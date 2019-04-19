using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//clase para guardar un array con los sonidos de cada nivel

[System.Serializable]
public class Sounds {

    public string name;
    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;

}
