using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour {

    private Rigidbody2D rb;
    PlayerMovement playerMov;

    //private Vector2 impulse;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        playerMov = GetComponent<PlayerMovement>();
    }

    // impulsa al GameObject en la dirección del parametro
    public void KnockGO(Vector2 dir, float knockForce, float timeUntilRecoveringControl)
    {
        rb.AddForce(dir * knockForce, ForceMode2D.Impulse);
        playerMov.SetInputActive(false);
        Invoke("ActivateControl", timeUntilRecoveringControl);
    }

    public void BumpOnTop(Vector2 dir, float forceOnBump)
    {
        rb.AddForce(dir * forceOnBump, ForceMode2D.Impulse);
    }

    public void ActivateControl()
    {
        playerMov.SetInputActive(true);
    }
}
