using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float xDir = 0;
    public float yDir = 0;
    public float zDir = -1;
    public float speed;
    public float initialSpeed = 0.02f;
    public float topSpeed = 0.1f;
    public float accelerationRate = 1;
    public float loopTime = 300f;

    // Use this for initialization
    void Start () {

        speed = initialSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump"))
        {
            Accelerate();
        } else
        {
            Decelerate(true);
        }
        Move();
    }

    void Move()
    {
        transform.position += new Vector3(xDir, yDir, zDir) * speed;
    }

    void Accelerate()
    {
        if(speed < topSpeed)
        {
            speed = Mathf.Clamp(speed + (speed * accelerationRate), -1000, topSpeed);
        }
    }

    void Decelerate(bool isReverting)
    {
        float decelerationLimit = 0;
        if (isReverting)
        {
            decelerationLimit = initialSpeed;
        }
        if (speed > decelerationLimit)
        {
            speed = Mathf.Clamp(speed - (speed * accelerationRate), decelerationLimit, 1000);
        }
    }
}
