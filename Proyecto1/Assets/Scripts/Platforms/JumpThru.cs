using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThru : MonoBehaviour {

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") < 0) GoThru();
        else if (Input.GetAxisRaw("Vertical") >= 0) Solidify();

    }
    void GoThru()
    {
        if (Input.GetAxisRaw("Vertical") < 0) this.gameObject.GetComponent<Collider2D>().enabled = false;
    }
    void Solidify()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
