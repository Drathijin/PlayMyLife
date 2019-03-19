using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCameraFollow : MonoBehaviour {
    public Transform Player;
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(Player.position.x, transform.position.y, transform.position.z);
	}
}
