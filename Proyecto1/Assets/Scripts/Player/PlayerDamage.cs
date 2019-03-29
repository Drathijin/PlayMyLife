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
<<<<<<< HEAD:Proyecto1/Assets/Scripts/PlayerDamage.cs
        GameManager.instance.LoseLevel();
=======
        GameManager.instance.FinishLevel(false);
>>>>>>> GuardarPartidas:Proyecto1/Assets/Scripts/Player/PlayerDamage.cs
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
