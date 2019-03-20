using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnExitZone : MonoBehaviour {

    public float TimeToLose;

    private float playerTime;
    private bool outside;
    private bool oneTime;
    public  UIManager UI;

	// Use this for initialization
	void Start () {
        playerTime = 0;
        outside = true;
        oneTime = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!oneTime)
        {
            if (outside)
            {
                playerTime += Time.deltaTime;
                UI.TimeOutside((5-(int)playerTime));
            }
            if (playerTime > TimeToLose)
            {
                print("YOU LOSE!");
                oneTime = true;
                UI.TimeEntered(false);
            }
        }
	}
    

    // cuando haya un GM indicará que has perdido

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!oneTime)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerTime = 0;
                outside = false;
                print("You entered the zone");
                UI.TimeEntered(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!oneTime)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                outside = true;
                print("You exited the zone");
            }
        }
    }
}
