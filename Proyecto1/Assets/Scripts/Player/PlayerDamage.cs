using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    private float animationChangeTime = 0.5f;

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
<<<<<<< HEAD:Proyecto1/Assets/Scripts/PlayerDamage.cs
        GameManager.instance.LoseLevel();
=======
        GameManager.instance.FinishLevel(false);
>>>>>>> GuardarPartidas:Proyecto1/Assets/Scripts/Player/PlayerDamage.cs
        gameObject.SetActive(false); // desactiva al jugador
    }

    public void ReceiveDamage()
    {
        if (shield)
        {
            animator.SetBool("IsDamaged", true);
            armAnim.SetBool("IsDamaged", true);
            shieldObject.SetActive(false);
            shield = false;
            animTime = 0;
        }
        else PlayerDead();
    }
}
