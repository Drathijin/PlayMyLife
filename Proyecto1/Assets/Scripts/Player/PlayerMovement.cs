using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, height, dashDecreaseRate, impulseOnDash;
    bool jump, dashing = false, dashCD, input = true;
    bool ableToJump;
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
        else if (Input.GetAxisRaw("Vertical")> 0 && ableToJump && !jump) { jump = true; }
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            animator.SetBool("IsDashing", false);
            dashing = false;
        }
    }

    //Declaramos la velocidad del jugador en el eje X y en el eje Y
    void FixedUpdate()
    {
        //raycast para el salto
        //generamos dos raycasts en los pies del jugador (-0.8f es un offset manual)
        RaycastHit2D hit_floor1 = Physics2D.Raycast(new Vector2(transform.position.x + transform.lossyScale.x, transform.position.y - transform.lossyScale.y - 0.8f), Vector2.down);
        RaycastHit2D hit_floor2 = Physics2D.Raycast(new Vector2(transform.position.x - transform.lossyScale.x, transform.position.y - transform.lossyScale.y - 0.8f), Vector2.down);

        //comprobamos que choque con algo y que la distancia a la que choca sea casi nula
        if ((hit_floor1.collider != null || hit_floor2.collider != null) &&
            (hit_floor1.distance < 0.1 || hit_floor2.distance < 0.1)) ableToJump = true;
        else ableToJump = false;

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

    //intento de salto con colisiones
/*  private void OnCollisionEnter2D(Collision2D collision)
    {
        //primero comprobamos si se puede activar para evitar hacer el cálculo innecesariamente
        if (!ableToJump)
        {
            ContactPoint2D contact = collision.GetContact(0);
            if (contact.point.y < transform.position.y - transform.lossyScale.y &&
                Mathf.Approximately(Vector2.Angle(contact.normal, transform.up), 0))
                ableToJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        try
        {
            ContactPoint2D contact = collision.GetContact(0);
            if (contact.point.y < transform.position.y - transform.lossyScale.y)
                ableToJump = false;
        }
        catch { ableToJump = false; }
    }*/

    public void SetInputActive(bool state)
    {
        input = state;
    }
}