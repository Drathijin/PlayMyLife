using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    //public KeyCode tecla; //tecla de disparo
    public Bullet bullet; //Objeto que se instanciará
    public Transform points;
    public float cooldown;

    private Transform arm;
    private GameObject bulletpool; //objeto padre de las balas, para mantener organización
    private bool disparoActv; //activa y desactiva la capacidad de disparar del jugador


    void Start()
    {
        bulletpool = GameObject.Find("BulletPool"); //busca al padre de las balas
        disparoActv = true;
        arm = transform.GetChild(1);
    }

    //si se pulsa la tecla de disparo (Edit-->Input-->Axis-->Fire1) y el cooldown está inactivo, dispara
    private void Update()
    {
        if (disparoActv && Input.GetAxisRaw("Fire1")!=0) //Aunque he puesto left y right como "Fire1", pero para detectar si está pulsado o no hay que hacer esto
        {
            Invoke("Cooldown", cooldown);
            arm.GetComponent<Animator>().SetBool("IsShooting", true);
            disparoActv = false;
            ShootBullet();
        }
    }

    //se invoca desde update, tras 1 segundo, al disparar
    void Cooldown()
    {
        disparoActv = true;
        arm.GetComponent<Animator>().SetBool("IsShooting", false);
    }

    //instancia una nueva bala y la lanza
    void ShootBullet()
    {
        float dir = Input.GetAxisRaw("Fire1"); // si está pulsado la izq, el float de getAxis es negativo, en contrario es positivo
        if (dir >0)
        {
            // comprueba si esta hacia donde mira el player
            if(transform.localScale.x >= 0)
            {
                arm.rotation = new Quaternion(0, 0, 0, 0);
            }
            else arm.rotation = new Quaternion(0, 0, 180, 0);
        } //Aunque la posicion del shootpoint en el inspector es 0.5f 
        
        //respecto de su padre , pero si ponemos manualmente 0.5f, lo que se va a colocar es respecto el mundo de unity.
        else if (dir <0)
        {
            if (transform.localScale.x >= 0)
            {
                arm.rotation = new Quaternion(0, 0, 180, 0);
            }
            else arm.rotation = new Quaternion(0, 0, 0, 0);
        }
        
        Bullet newbullet = Instantiate(bullet, points.position, Quaternion.identity, bulletpool.transform);
        newbullet.ChangeDir(arm.right * transform.localScale.x);
    }
}
