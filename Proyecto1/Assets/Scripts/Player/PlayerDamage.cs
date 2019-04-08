using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

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
        GameManager.instance.FinishLevel(false);
        gameObject.SetActive(false); // desactiva al jugador
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
    }
}
