using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

    public float Speed = 1; 

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

        if(objectives.Length > 0)
            transform.position = objectives[pointer].position;

        if (objectives.Length > 1)
            ChangeDirec();
        else noPath = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!noPath)
        {
            if (CollPath())
                ChangeDirec();
            
            transform.Translate(direc.normalized * Speed * Time.deltaTime);
        }
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
        if (pointer == objectives.Length)
            pointer = 0;

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
}