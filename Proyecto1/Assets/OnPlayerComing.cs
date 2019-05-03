using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerComing : MonoBehaviour {

    public Transform playerTrans;
    FollowPath Follow;
    private void Start()
    {
        Follow = GetComponent<FollowPath>();

    }
    private void Update()
    {
        if (playerTrans.position.x > transform.position.x - 12f)
        {
            Follow.enabled = true;
        }
    }
}
