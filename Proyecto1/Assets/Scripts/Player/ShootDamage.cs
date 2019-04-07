﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDamage : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "EnemyShield")
        {
            Destroy(collision.gameObject); // Es un código simple para BlackBullet, destruirá todo lo que se va a colisionar. Entonces hay que hace que la máscara 
                                           // de colisión de Blackbullet solo se puede colisionar con breakWall y Enemy.
                                           // BreakWall es un simple sprite con box collider2d, no tiene scripts.
            GameManager.instance.KillEnemy();

        }

        Destroy(this.gameObject);
    }
}
