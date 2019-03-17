using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    
    GameObject player;
    public float horizontalOffset = 5, verticalOffset = 5;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void LateUpdate()
    {
        //transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

        if (player.transform.position.x > transform.position.x + horizontalOffset)
        {
            transform.position = new Vector3(player.transform.position.x - horizontalOffset, transform.position.y, transform.position.z);
        }
        else if (player.transform.position.x < transform.position.x - horizontalOffset)
        {
            transform.position = new Vector3(player.transform.position.x + horizontalOffset, transform.position.y, transform.position.z);
        }

        if (player.transform.position.y > transform.position.y + verticalOffset)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - verticalOffset, transform.position.z);
        }
        else if (player.transform.position.y < transform.position.y - verticalOffset)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y + verticalOffset, transform.position.z);
        }
    }
}
