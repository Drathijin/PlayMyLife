using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeParentOnColl : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Mathf.Abs(Vector2.Angle(collision.GetContact(0).normal, transform.up) - 180) < 0.1f) // si cae encima
        {
            collision.gameObject.transform.SetParent(this.transform); // pon la plataforma como el padre del otro objeto
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Mathf.Abs(Vector2.Angle(collision.GetContact(0).normal, transform.up) - 180) < 0.1f) // si cae encima
        {
            collision.gameObject.transform.SetParent(this.transform); // pon la plataforma como el padre del otro objeto
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Transform level = GameObject.Find("Level").transform;
        collision.gameObject.transform.SetParent(level); // pon el objeto hijo de Level
    }
}
