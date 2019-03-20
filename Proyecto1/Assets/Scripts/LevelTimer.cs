using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour {
    
    public bool WinOnTimeOut = false; // si true, el jugador gana al terminar el tiempo, si false, el jugador pierde
    public float MaxSeconds = 0; // segundos totales
    

    private float timer; // tiempo transcurrido
    private bool oneTime = true; // se asegura que solo se ejecuta una vez

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (timer < MaxSeconds ) timer = timer + Time.deltaTime;
        else if(oneTime)
        {
            if (WinOnTimeOut) print("YOU WIN!!");
            else print("YOU LOST!!");

            oneTime = false;
        }
	}

    // llamara a GM y avisará de victoria o derrota
}
