using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    public GameObject PlayerMesh;
    public float speed;
    public float initialSpeed = 0.02f;
    public float topSpeed = 0.1f;
    public float accelerationRate = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump"))
        {
            Accelerate();
        }
        else
        {
            Decelerate(true);
        }
        Move();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Rotation
        transform.Rotate(moveHorizontal * Vector3.up * 2);
        PlayerMesh.transform.Rotate(moveVertical * Vector3.right * 2);
        
        // Movement
        transform.position += PlayerMesh.transform.forward * speed;
    }

    void Accelerate()
    {
        if (speed < topSpeed)
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
