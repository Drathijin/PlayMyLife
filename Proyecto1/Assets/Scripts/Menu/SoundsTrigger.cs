using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsTrigger : MonoBehaviour {

    public string clipName;

    //cuando entras en el trigger, se reproduce la pista de audio una sola vez
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.PlayClip(clipName);
        Destroy(this.gameObject);
    }
}
