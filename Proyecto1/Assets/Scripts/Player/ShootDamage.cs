using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDamage : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        if (collision.gameObject.tag != "NotDestructible")
        {
            Destroy(collision.gameObject); 
            // Es un código simple para PlayerBullet, destruya todo lo que se va a colisionar. Entonces hay que hace que la máscara 
            // de colisión de Playerbullet solo pueda colisionar con breakWall y Enemy.
            // BreakWall es un simple sprite con box collider2d, no tiene scripts.
            GameManager.instance.KillEnemy();
        }

    }
}
