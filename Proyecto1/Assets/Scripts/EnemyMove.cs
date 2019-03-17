using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float enemySpeed;     //Valor modificable de valocidad



    Rigidbody2D enemyRb;
    private float startPosition;          //Lugar donde colocaste el enemigo
    public float offset = 3f;      //Offset*2 = Distancia que puede mover el enemigo


    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        startPosition = this.transform.position.x;        //Invocado desde start
    }
    private void Update()
    {
        if (this.transform.position.x >= startPosition + offset && enemySpeed>0)           //la mitad de la distancia de movimiento = limite del movimiento por izquierda y por derecha del enemigo
            enemySpeed = -enemySpeed;
        else if (this.transform.position.x <= startPosition - offset && enemySpeed < 0)        //añaddos && >/< que 0 para que no se repita el código varias veces en un mismo rebote
            enemySpeed = -enemySpeed;
    }

    private void FixedUpdate()
    {
        enemyRb.velocity = new Vector2(enemySpeed, enemyRb.velocity.y);                  //Velocidad constante
    }
}