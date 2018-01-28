using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLerp : MonoBehaviour {

    public GameObject player;
    public float speed = 2.0f;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        transform.position = player.transform.position + offset;

        //transform.LookAt(player.transform.parent);
    }
}
