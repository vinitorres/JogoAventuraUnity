using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public Transform player;
    Vector3 offset;

	void Start () {
        offset = new Vector3(1.0f, 2.0f, -10f);
   	}

    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
}
