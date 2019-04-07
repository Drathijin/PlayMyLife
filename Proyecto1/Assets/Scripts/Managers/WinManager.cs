using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour {
    public bool winOnTimeOut = true; // true ganar false perder
    public float maxSeconds = -1; // segundos máximos
    public int maxCollectables = -1; // coleccionables totales
    public int maxKills = -1; // score total

    private float timer = 0; // tiempo transcurrido
    private int collectables = 0; // contador de colleccionables
    private int killCount = 0; // contador del score
    private bool oneTime = true; // se asegura que solo se ejecuta una vez

    private void Awake()
    {
    }
    void Start() {
        GameManager.instance.SetWinManager(this);

        killCount = maxKills;
        oneTime = true;
    }

    void Update() {
        if (timer < maxSeconds) timer = timer + Time.deltaTime;
        else if (maxSeconds >-1 && oneTime)
        {
            if (winOnTimeOut)
            {
                GameManager.instance.FinishLevel(true);
            }
            else
            {
                GameManager.instance.FinishLevel(false);
            }

            oneTime = false;
        }

        if (((maxKills > -1 && killCount <= 0) || (maxCollectables > -1 && collectables >= maxCollectables)) && oneTime)
        {
            GameManager.instance.FinishLevel(true);
            oneTime = false;
        }
    }


    //Para Utilizar esta forma de ganar desde el editor ser equiere que se habilite el sprite renderer (para ver la bandera) y el rigidbody
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && oneTime)
        {
            oneTime = false;
            GameManager.instance.FinishLevel(true);

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
