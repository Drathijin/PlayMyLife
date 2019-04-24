using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, height, dashDecreaseRate, impulseOnDash;
    bool jump, dashing = false, dashCD, input = true;
    float speedX, jumpForce, dashAcc = 0, count = 0, dashCoolDown = 0.1f;
    Rigidbody2D rb;
    Animator animator;

    //Obtenemos el Rigidbody del jugador para modificar su velocidad
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //En el Update() declaramos los "controles" del jugador, para desplazarse en el eje X y para saltar en el eje Y
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal");// speedX = {-1, 0, 1}

        if (speedX >0)
        { transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); }

        else if (speedX <0)
        { transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); }

        animator.SetFloat("SpeedX", Mathf.Abs(rb.velocity.x));

        animator.SetFloat("SpeedY", Mathf.Abs(rb.velocity.y));


        if (Input.GetAxisRaw("Vertical") < 0 && !dashing && !dashCD) //quiero que solo se ejecute una vez
        {
            dashAcc = rb.velocity.x * impulseOnDash * dashDecreaseRate;
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f); //corregir la diferecncai de altura al agacharse
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

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            dashAcc *= dashDecreaseRate;
            dashing = true;
            
        }
        else if (Input.GetAxisRaw("Vertical")> 0 && Mathf.Abs(rb.velocity.y) < 0.1f && !jump) { jump = true; }
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            animator.SetBool("IsDashing", false);
            dashing = false;            
        }

    }

    //Declaramos la velocidad del jugador en el eje X y en el eje Y
    void FixedUpdate()
    {
        if (jump)
        {
            jumpForce = Mathf.Sqrt(height * -2 * Physics2D.gravity.y * rb.gravityScale);
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump = false;
        }

        if (dashing)
        {
            if (!dashCD)
            {
                if (input) rb.velocity = new Vector2(dashAcc, rb.velocity.y); //sólo hace dash si no ha sido knockeado
                //rb.AddForce(new Vector2(dashAcc, 0), ForceMode2D.Impulse);
                dashCD = true;
                animator.SetBool("IsDashing", true);
            }
        }
        else if (input) rb.velocity = new Vector2(speedX * speed, rb.velocity.y); //sólo se puede mover si no ha sido knockeado
    }

    public void SetInputActive(bool state)
    {
        input = state;
    }
}