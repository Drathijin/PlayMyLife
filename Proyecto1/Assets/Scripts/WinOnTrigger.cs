using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOnTrigger : MonoBehaviour
{
    private bool oneTime = true; // se asegura que solo se ejecuta una vez

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && oneTime)
        {
            print("YOU WIN!!");
            oneTime = false;
        }
    }

    // llamara al GM y avisará de la victoria
}
