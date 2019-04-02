using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float seconds;  //tiempo que tarda en desaparecer el objeto

    //cuando se crea, el objeto tarda "seconds" segundos en ser destruido
    void Start()
    {

        Destroy(gameObject, seconds);
    }

    public void GetDestroyed()
    {
        Destroy(gameObject);
    }
}
