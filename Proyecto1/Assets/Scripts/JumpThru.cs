using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThru : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) GoThru();
        else if (Input.GetKeyUp(KeyCode.S)) Solidify();

    }
    void GoThru()
    {
        if (Input.GetKeyDown(KeyCode.S)) this.gameObject.GetComponent<Collider2D>().enabled = false;
    }
    void Solidify()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
