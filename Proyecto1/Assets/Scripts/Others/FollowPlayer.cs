using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    
    GameObject player;
    public float horizontalOffset = 5, verticalOffset = 5;
    public float horizontalCenterOffset = 0, verticalCenterOffset = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void LateUpdate()
    {
        //transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

        if (player.transform.position.x > transform.position.x + horizontalOffset)
        {
            transform.position = new Vector3(player.transform.position.x - horizontalOffset + horizontalCenterOffset, transform.position.y + verticalCenterOffset, transform.position.z);
        }
        else if (player.transform.position.x < transform.position.x - horizontalOffset)
        {
            transform.position = new Vector3(player.transform.position.x + horizontalOffset + horizontalCenterOffset, transform.position.y + verticalCenterOffset, transform.position.z);
        }

        if (player.transform.position.y > transform.position.y + verticalOffset)
        {
            transform.position = new Vector3(transform.position.x + horizontalCenterOffset, player.transform.position.y - verticalOffset + verticalCenterOffset, transform.position.z);
        }
        else if (player.transform.position.y < transform.position.y - verticalOffset)
        {
            transform.position = new Vector3(transform.position.x + horizontalCenterOffset, player.transform.position.y + verticalOffset + verticalCenterOffset, transform.position.z);
        }
    }
}
