using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, height, dashDecreaseRate, impulseOnDash;
    bool jump, dashing = false, dashCD, input = true;
    float speedX, jumpForce, dashAcc = 0, count = 0, dashCoolDown = 0.1f;
    Rigidbody2D rb;

    //Obtenemos el Rigidbody del jugador para modificar su velocidad
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //En el Update() declaramos los "controles" del jugador, para desplazarse en el eje X y para saltar en el eje Y
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal");// speedX = {-1, 0, 1}
        if (speedX >0)
        { transform.localScale = new Vector3(1, 1, 1); }

        else if (speedX <0)
        { transform.localScale = new Vector3(-1, 1, 1); }

        if (Input.GetKeyDown(KeyCode.S))
        {
            dashAcc = rb.velocity.x * impulseOnDash / dashDecreaseRate;
            transform.localScale = new Vector3(1, 0.75f, 1);
        }
        else if (dashCD)
        {
            if (count < dashCoolDown) count = count + Time.deltaTime;
            //Contador para no poder spamear el dash e impulsarse
            else
            {
                count = 0;
                dashCD = false;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            dashAcc *= dashDecreaseRate;
            dashing = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.1f) { jump = true; }
        else
        {
            if (Input.GetKeyUp(KeyCode.S)) transform.localScale = new Vector3(1, 1, 1);
            else dashing = false;
        }

    }

    //Declaramos la velocidad del jugador en el eje X y en el eje Y
    void FixedUpdate()
    {
        if (jump)
        {
            jumpForce = Mathf.Sqrt(height * -2 * Physics2D.gravity.y * rb.gravityScale) * rb.drag - 2;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        if (dashing)
        {
            if (!dashCD)
            {
                if (input) rb.velocity = new Vector2(dashAcc, rb.velocity.y); //sólo hace dash si no ha sido knockeado
                //rb.AddForce(new Vector2(dashAcc, 0), ForceMode2D.Impulse);
                dashCD = true;
            }
        }
        else if (input) rb.velocity = new Vector2(speedX * speed, rb.velocity.y); //sólo se puede mover si no ha sido knockeado
    }

    public void SetInputActive(bool state)
    {
        input = state;
    }
}