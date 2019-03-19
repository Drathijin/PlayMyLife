using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour {

    public bool killsInstantly;

    public void Damage(Collision2D other)
    {
        PlayerDamage playerDamage = other.gameObject.GetComponent<PlayerDamage>();
        if (killsInstantly) playerDamage.PlayerDead();
        else playerDamage.ReceiveDamage();
    }
}
