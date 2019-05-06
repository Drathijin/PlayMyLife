using UnityEngine;
 
 public class MusicClass : MonoBehaviour
 {
     public AudioSource _audioSource;
     private void Awake()
     {   
        MusicClass mC = null;
        try
        {
            GameObject audio = GameObject.FindGameObjectWithTag("Music");
            mC = audio.GetComponent<MusicClass>();
            if(mC._audioSource.isPlaying)
                Destroy(this.gameObject);
            else
            {
                DontDestroyOnLoad(transform.gameObject);
                _audioSource = GetComponent<AudioSource>();
                PlayMusic();
            }
        }
        catch
        {
            DontDestroyOnLoad(transform.gameObject);
            _audioSource = GetComponent<AudioSource>();
            PlayMusic();
        }


     }
 
     public void PlayMusic()
     {
         if (!_audioSource.isPlaying) _audioSource.Play();
     }
 
     public void StopMusic()
     {
         _audioSource.Stop();
     }
 }