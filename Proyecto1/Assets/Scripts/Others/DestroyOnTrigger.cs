using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (this.gameObject.tag == "Collectable") CountUp();
    }

    private void CountUp()
    {
        GameManager.instance.AddCollectable();        
        try
        {
            this.GetComponent<Collider2D>().enabled=false;
            this.GetComponent<SpriteRenderer>().enabled=false;
            AudioManager.instance.PlayClip(this.gameObject);
        }
        catch (System.Exception e)
        {
            Destroy(this.gameObject);
            print(e);
        }
    }
}