using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    public float speed = 1;

    public Transform[] objectives; // lista de objetivos en orden que sigue

    private Vector2 direc; // direccion de a recorrer
    private int pointer; // indice de objectives[]
    //noPath = si no hay camino que recorrer, left = si esta a la izquierda del siguiente objetivo, under = si esta debajo del siguiente objetivo
    private bool noPath, left, under;

    // Use this for initialization
    void Start()
    {
        pointer = 0;

        noPath = false;

        direc = Vector2.zero;

        if (objectives.Length > 0)
            transform.position = objectives[pointer].position;

        if (objectives.Length > 1)
            ChangeDirec();
        else noPath = true;
    }

    // Update is called once per frame
    void Update()
    {
        // si no hay camino no te muevas
        if (!noPath)
        {
            // si hay colision cambia la direccion
            if (CollPath())
            {
                // se pone en la posicion con la que ha colisionado para evitar bugs con la horizontal y vertical
                transform.position = objectives[pointer].position;
                ChangeDirec();
            }

            transform.Translate(direc.normalized * speed * Time.deltaTime);
        }
    }

    // solo se accedera si el objeto no es un trigger
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // si colisionas por la parte de abajo, y el objeto esta descendiendo
        // if (Mathf.Approximately(Vector2.Angle(collision.GetContact(0).normal, transform.up), 0) && direc.y < 0)
        // {
        //     GoBack(); // ve hacia atras
        // }
    }

    // comprueba si ha colisionado con el siguiente objetivo
    private bool CollPath()
    {
        bool coll = false;

        if (left)
        {
            if (transform.position.x >= objectives[pointer].position.x)
                coll = true;
        }
        else if (transform.position.x <= objectives[pointer].position.x)
        {
            if (under)
            {
                if (transform.position.y >= objectives[pointer].position.y)
                    coll = true;
            }
            else if (transform.position.y <= objectives[pointer].position.y)
                coll = true;
        }

        return coll;
    }

    // cambia la direccion al siguiente objetivo
    private void ChangeDirec()
    {
        // recorre el vector de manera ciclica
        pointer++;

        // evita que el vector se salga del vector
        pointer = pointer % objectives.Length;

        left = true;
        under = true;

        // B - A
        direc = new Vector2(objectives[pointer].position.x - transform.position.x, objectives[pointer].position.y - transform.position.y);

        // comprueba si esta a la izquierda o debajo del objetivo
        if (transform.position.x >= objectives[pointer].position.x)
        {
            left = false;
        }
        if (transform.position.y >= objectives[pointer].position.y)
        {
            under = false;
        }
    }

    // metodo para hacer que el objeto de la vuelta, y retome su caminoo una vez colisione con el anterior objetivo
    private void GoBack()
    {
        // establece el indice a dos antes para que busque la siguiente
        pointer += objectives.Length - 2;
        ChangeDirec();
    }
}