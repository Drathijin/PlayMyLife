using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, height, dashDecreaseRate, impulseOnDash;
    public LayerMask ground;
    bool jump, dashing = false, dashCD, input = true;
    public bool ableToJump = false;
    float speedX, jumpForce, dashAcc = 0, count = 0, dashCoolDown = 0.1f;
    Rigidbody2D rb;
    Animator animator;
    BoxCollider2D collider;

    //Obtenemos el Rigidbody del jugador para modificar su velocidad
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //En el Update() declaramos los "controles" del jugador, para desplazarse en el eje X y para saltar en el eje Y
    void Update()
    {
        Debug.Log(rb.velocity.y);

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
        else if (Input.GetAxisRaw("Vertical") > 0 && /*Mathf.Abs(rb.velocity.y) < 0.1f*/ ableToJump && !jump) { jump = true; }
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            animator.SetBool("IsDashing", false);
            dashing = false;
        }

        animator.SetBool("ableToJump", ableToJump);
    }

    //auxiliar para debug del salto
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - (collider.size.y * transform.localScale.y / 2)),
                        new Vector2(collider.size.x * transform.localScale.x / 2, 0.05f));
    }

    //Declaramos la velocidad del jugador en el eje X y en el eje Y
    void FixedUpdate()
    {
        ableToJump = Physics2D.OverlapArea(new Vector2(transform.position.x - (collider.size.x * transform.localScale.x / 4), 
                                                        transform.position.y - (collider.size.y * transform.localScale.y / 2)), 
                                            new Vector2(transform.position.x + (collider.size.x * transform.localScale.x / 4),
                                                        transform.position.y - (collider.size.y * transform.localScale.y / 2)),
                                            ground);

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