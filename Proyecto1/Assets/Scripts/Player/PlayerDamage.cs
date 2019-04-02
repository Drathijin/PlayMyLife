using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    bool shield = true;
    Shield shieldObject;

    private void Start()
    {
        shieldObject = GetComponentInChildren<Shield>();
    }

    public void PlayerDead()
    {
        GameManager.instance.FinishLevel(false);
        gameObject.SetActive(false); // desactiva al jugador
    }

    public void ReceiveDamage()
    {
        if (shield)
        {
            shieldObject.SetActive(false);
            shield = false;
        }
        else PlayerDead();
    }
}
