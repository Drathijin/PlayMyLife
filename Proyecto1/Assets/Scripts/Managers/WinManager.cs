using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public bool winOnTimeOut = true; // true ganar false perder
    public float maxSeconds = -1; // segundos máximos
    public int maxCollectables = -1; // coleccionables totales
    public int maxKills = -1; // score total

    public AudioSource winSound;
    public AudioSource loseSound;
    #region Privates
    private float timer; // tiempo transcurrido
    private int collectables = 0; // contador de colleccionables
    private int killCount = 0; // contador del score
    private bool oneTime = true; // se asegura que solo se ejecuta una vez
    private bool cheat; //booleano usado para terminar niveles de forma automática para el testing  de niveles
    #endregion
    void Start() {
        GameManager.instance.SetWinManager(this);

        killCount = maxKills;
        oneTime = true;
        timer = maxSeconds;
    }

    void Update() {
        if (timer > 0) timer -= Time.deltaTime;
        else if (maxSeconds > -1 && oneTime)
        {
            if (winOnTimeOut)
            {
                FinishLevel(true);
            }
            else
            {
                FinishLevel(false);
            }

            oneTime = false;
        }

        if (((maxKills > -1 && killCount <= 0) || (maxCollectables > -1 && collectables >= maxCollectables)) && oneTime)
        {
            FinishLevel(true);
            oneTime = false;
        }
        else if(GetCheat(out cheat))
        {
            print(cheat);
            FinishLevel(cheat);
            oneTime = false;
        }
    }
    private void FinishLevel(bool w)
    {
        GameManager.instance.FinishLevel(w);
    }

    public void PlayEndSound(bool w)
    {
        
        try
        {
            if (w)
            {
                AudioManager.instance.PlayClip(winSound);
            }
            else 
            {
                AudioManager.instance.PlayClip(loseSound);
            }
        }
        catch (System.Exception e)
        {
            print(e);
        }
    }

    private bool GetCheat(out bool _cheat) //Con L+O o W+I superas los niveles de manera instantanea para testeos.
    {
        if(Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.O))
        {
            _cheat = false;
            return true;
        } if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.I))
        {
            _cheat = true;
            return true;
        }
        _cheat = false;
        return false;
    }


    //Para Utilizar esta forma de ganar desde el editor ser equiere que se habilite el sprite renderer (para ver la bandera) y el rigidbody
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player" && oneTime)
        {
            oneTime = false;
            FinishLevel(true);

        }
    }
    public void SubKillCount()
    {
        killCount--;
        print(killCount);
    }
    public void AddCollectable()
    {
        collectables++;
    } 
    public int GetCollectables()
    {
        return collectables;
    }
    public int GetKillCount()
    {
        return killCount;
    }
    public float GetTime()
    {
        return timer;
    }

}
