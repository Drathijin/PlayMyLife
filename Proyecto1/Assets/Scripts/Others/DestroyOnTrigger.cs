using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
        if (this.gameObject.tag == "Collectable") CountUp();
    }

    static void CountUp()
    {
        GameManager.instance.AddCollectable();        
    }
}