﻿using System.Collections;
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
    Player_Audio audioController;


    void Start()
    {
        animTime = animationChangeTime;
        shieldObject = GetComponentInChildren<Shield>();
        animator = GetComponent<Animator>();
        armAnim = transform.GetChild(1).GetComponent<Animator>();
        try
        {
            audioController = GetComponentInChildren<Player_Audio>();
        }
        catch
        {
            print("no se encuentra Player_Audio en los hijos");
        }
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
        if(Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.I)) this.enabled = false;  
    }

    public void PlayerDead()
    {
        animator.SetBool("IsDead", true);
        armAnim.SetBool("IsDead", true);
        shieldObject.SetActive(false);
        audioController.PlayDead();

        gameObject.GetComponent<PlayerMovement>().enabled = false; // desactiva el movimiento del jugador
        gameObject.GetComponent<PlayerShoot>().enabled = false; // desactiva el disparo del jugador
        gameObject.GetComponent<KnockBack>().enabled = false; // desactiva el knockback del jugador
        Rigidbody2D m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        m_Rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
        m_Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        m_Rigidbody.bodyType = RigidbodyType2D.Static;
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
            audioController.PlayDamage();
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
