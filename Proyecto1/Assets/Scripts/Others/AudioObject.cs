using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioObject : MonoBehaviour {

    public AudioMixer masterMixer;
    public AudioSource clip;
    public AudioManager AudioManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.SetCurrentClip(this);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("KillMe", clip.clip.length);
    }

    public void KillMe()
    {
        Destroy(this.gameObject);
    }
    public void Play()
    {
        clip.Play();
    }
}
