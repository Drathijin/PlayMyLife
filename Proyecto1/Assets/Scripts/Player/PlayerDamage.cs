using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float invulnerableTime = 100f;

    private float animationChangeTime = 1f;

    private float animTime;
    bool shield = true;
    Shield shieldObject;
    Animator animator, armAnim;

    void Start()
    {
        animTime = animationChangeTime;
        shieldObject = GetComponentInChildren<Shield>();
        animator = GetComponent<Animator>();
        armAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    private void Update()
    {
        if (animTime < animationChangeTime)
        {
            animTime += Time.deltaTime;
        }
        else
        {
            animator.SetBool("IsDamaged", false);
            armAnim.SetBool("IsDamaged", false);
        }
    }

    public void PlayerDead()
    {
        animator.SetBool("IsDead", true);
        armAnim.SetBool("IsDead", true);

        gameObject.GetComponent<PlayerMovement>().enabled = false; // desactiva el movimiento del jugador
        GameManager.instance.FinishLevel(false);

    }

    public void ReceiveDamage()
    {
        if (shield)
        {
            shieldObject.SetActive(false);
            shield = false;
            animator.SetBool("IsDamaged", true);
            armAnim.SetBool("IsDamaged", true);
            animTime = 0;

        }
        else PlayerDead();
        //animator matame
        Invoke("ActivateMe", invulnerableTime);
        this.enabled = false;

    }

    void ActivateMe()
    {
        this.enabled = true;
        animator.SetBool("IsDamaged", false);
        armAnim.SetBool("IsDamaged", false);


    }
}
