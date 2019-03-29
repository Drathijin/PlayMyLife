using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    /*
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime); //movemos la velocidad de la bala
    }
    */

    //método para cambiar la dirección de la bala
    public void ChangeDir(Vector2 rotation)
    {
        transform.right = rotation;
    }

}
