using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour {

    public bool breaks; //indica si la plataforma se rompe o no
    public bool regenerates; //indica si la plataforma se regenera o no
    public float timeUntilBreak; //tiempo hasta que se rompe;
    public float timeUntilRegen; //tiempo hasta que se regenera

    private bool anim = false;
    private SpriteRenderer spr;

    private void Start()
    {
        spr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (anim)
        {
            Color temp;
            temp = spr.color;
            temp.a -= Time.deltaTime / timeUntilBreak;
            spr.color = temp;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //comprueba colisiones con el jugador
        if (breaks && collision.gameObject.CompareTag("Player"))
        {
            anim = true;
            //invoca al metodo de romper tras <timeUntilBreak> segundos
            Invoke("BreakObject", timeUntilBreak);
        }
    }

    //"rompe" la plataforma e invoca regeneración
    public void BreakObject()
    {
        gameObject.SetActive(false);
        //si la plataforma se regenera, invoca la regeneración tras <timeUntilRegen> segundos
        if(regenerates) Invoke("Regenerate", timeUntilRegen);
    }

    //regeneración de la plataforma
    public void Regenerate()
    {
        Color temp;
        temp = spr.color;
        temp.a = 255;
        spr.color = temp;
        gameObject.SetActive(true);
    }
}
