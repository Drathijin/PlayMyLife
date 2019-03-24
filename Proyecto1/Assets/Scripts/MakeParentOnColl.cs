using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeParentOnColl : MonoBehaviour {

    bool parented = false; // para que solo ponga al otro objeto hijo de Level cuando no lo sea

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Mathf.Approximately(Vector2.Angle(collision.GetContact(0).normal, transform.up), 180)) // si cae encima
        {
            collision.gameObject.transform.SetParent(this.transform); // pon la plataforma como el padre del otro objeto

            parented = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (parented) // si sale y esta como hijo del otro objeto
        {
            Transform level = GameObject.Find("Level").transform;
            collision.gameObject.transform.SetParent(level); // pon el objeto hijo de Level

            parented = false;
        }
    }
}
