using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{

    public GameObject player;
    public float speed = 0.02f;
    public bool isChaseEnabled = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isChaseEnabled)
            Chase();
    }

    void Chase()
    {
        transform.LookAt(player.transform);
        transform.position += (transform.forward * speed);
    }
}
