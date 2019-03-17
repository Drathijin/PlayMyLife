using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCount : MonoBehaviour {

    public float ScoreToWin = 0; // puntuacion para ganar

    private float score = 0; // puntuacion actual
    private bool oneTime = true; // se asegura que solo se ejecuta una vez

    // Use this for initialization
    private void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= ScoreToWin && oneTime)
        {
            print("YOU WIN!!");
            oneTime = false;
        }
    }

    public void AddScore(float value)
    {
        score += value;
    }

    // necesita puntuacion desde el GM
}
