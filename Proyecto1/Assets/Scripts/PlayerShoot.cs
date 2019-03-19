using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    //public KeyCode tecla; //tecla de disparo
    public Bullet bullet; //Objeto que se instanciará
    public Transform points;
    public float cooldown;
    private GameObject bulletpool; //objeto padre de las balas, para mantener organización
    private bool disparoActv; //activa y desactiva la capacidad de disparar del jugador
    float offset = 0.5f;    // distancia entre player y su shootpoints


    void Start()
    {
        bulletpool = GameObject.Find("BulletPool"); //busca al padre de las balas
        disparoActv = true;

    }

    //si se pulsa la tecla de disparo (Edit-->Input-->Axis-->Fire1) y el cooldown está inactivo, dispara
    private void Update()
    {
        if (disparoActv && (Input.GetKeyDown("left")|| Input.GetKeyDown("right"))) //Aunque he puesto left y right como "Fire1", pero para detectar si está pulsado o no hay que hacer esto
        {
            Invoke("Cooldown", cooldown);
            disparoActv = false;
            ShootBullet();
        }
    }

    //se invoca desde update, tras 1 segundo, al disparar
    void Cooldown()
    {
        disparoActv = true;
    }

    //instancia una nueva bala y la lanza
    void ShootBullet()
    {
        float dir = Input.GetAxisRaw("Fire1"); // si está pulsado la izq, el float de getAxis es negativo, en contrario es positivo
        if (dir >0)
        { points.position = new Vector2 (transform.position.x + offset,transform.position.y); } //Aunque la posicion del shootpoint en el inspector es 0.5f 
        //respecto de su padre , pero si ponemos manualmente 0.5f, lo que se va a colocar es respecto el mundo de unity.
        else if (dir <0)
        { points.position = new Vector2(transform.position.x - offset, transform.position.y); }
        
        Bullet newbullet = Instantiate(bullet, points.position, Quaternion.identity, bulletpool.transform);
        Vector2 rotation = new Vector2 (points.position.x - transform.position.x, points.position.y - transform.position.y);
        newbullet.ChangeDir(rotation);
    }
}
