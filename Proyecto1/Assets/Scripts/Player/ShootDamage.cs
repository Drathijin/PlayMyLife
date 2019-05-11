using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDamage : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "BreakWall")
        {
            Animator wall = collision.gameObject.GetComponent<Animator>();
            if (wall != null)
            {
                wall.SetTrigger("Open");
                AudioSource a;
                try
                {
                    a =collision.gameObject.GetComponent<AudioSource>();
                    AudioManager.instance.PlayClip(a.clip);
                    Destroy(this.gameObject);
                }
                catch (System.Exception e){print("Puertas sin audio" +e);}
            }
        }
        else 
        if (collision.gameObject.tag == "Enemy")
        {
            try
            {
                collision.gameObject.GetComponent<OnPlayerContact>().KillMe();
            }
            catch (Exception e)
            {
                print("Enemigo sin PlayerContact" + e);
                Destroy(collision.gameObject);
            }
        }
        
        KillMe();
    }
    private void KillMe()
    {
        this.GetComponent<Collider2D>().enabled=false;
        this.GetComponent<SpriteRenderer>().enabled=false;
        try
        {
            AudioManager.instance.PlayClip(this.gameObject);
        }
        catch
        {
            Destroy(this.gameObject);
        }
    }
}
