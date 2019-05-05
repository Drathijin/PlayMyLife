using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThru : MonoBehaviour {

    bool enableGoThru = true;

    void Update()
    {
        if (enableGoThru)
        {
            if (Input.GetAxisRaw("Vertical") < 0) GoThru();
            else if (Input.GetAxisRaw("Vertical") >= 0) Solidify();
        }
    }
    void GoThru()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        enableGoThru = false;
        Invoke("SetAbleGoThru", 0.5f);
    }
    void Solidify()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }

    void SetAbleGoThru() { enableGoThru = true; }
}
