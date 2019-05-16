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
        if (GetCheatTime()) print(timer);
    }

    private bool GetCheatTime()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus) && Input.GetKey(KeyCode.LeftAlt))
        {
            timer -= 10;
            return true;

        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus) && Input.GetKey(KeyCode.LeftAlt))
        {
            timer += 10;
            return true;

        }
        return false;
    }

    private void FinishLevel(bool w)
    {
        GameObject player=null;
        try
        {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerShoot>().enabled = false;
            if(!w)
            {
                player.GetComponent<Animator>().SetBool("IsDead",true);
                player.GetComponentInChildren<Animator>().SetBool("IsDead",true);
            }
        }
        catch{print(player);}
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
                Invoke("LoseSound", GameManager.instance.GetLoseTime());
            }
        }
        catch (System.Exception e)
        {
            print(e);
        }
    }

    private void LoseSound()
    {
        AudioManager.instance.PlayClip(loseSound);
    }

    private bool GetCheat(out bool _cheat) //Con L+O o W+I superas los niveles de manera instantanea para testeos.
    {
        if(Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.LeftAlt))
        {
            print("reload");
            Destroy(this.gameObject);
            GameManager.instance.Reload();
            _cheat = false;
            return false;
        }
        if(Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.L))
        {
            _cheat = false;
            return true;
        }
        if(Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.W))
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
