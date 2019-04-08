using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnExitZone : MonoBehaviour {

    public float TimeToLose;
    public UIManager UI;

    private float playerTime;
    private bool outside;
    private bool oneTime;

	// Use this for initialization
	void Start ()
    {
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
                UI.TimeOutside(TimeToLose-playerTime);
            }
            if (playerTime > TimeToLose)
            {
                oneTime = true;
                UI.TimeEntered();
                GameManager.instance.FinishLevel(false);
            }
        }
	}
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!oneTime && collision.gameObject.CompareTag("Player"))
        {
            playerTime = 0;
            outside = false;
            UI.TimeEntered();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!oneTime && collision.gameObject.CompareTag("Player"))
        {
            outside = true;
        }
    }
}
