using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{

    public GameObject player;
    public float speed = 0.02f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    void Chase()
    {
        transform.LookAt(player.transform);
        transform.position += (transform.forward * speed);
    }
}
