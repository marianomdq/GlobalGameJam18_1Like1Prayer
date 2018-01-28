using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    public GameObject PlayerMesh;
    public float speed;
    public float initialSpeed = 0.02f;
    public float topSpeed = 0.1f;
    public float accelerationRate = 1;
    public float rotationLimit = 45f;

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
        float limit = rotationLimit / 100;
       
        // Rotation       
        transform.Rotate(moveHorizontal * Vector3.up * 2);
        if (transform.rotation.y > 0 && transform.rotation.y > limit)
        {
            transform.rotation = new Quaternion(transform.rotation.x, limit, transform.rotation.z, transform.rotation.w);
        } else if (transform.rotation.y < 0 && transform.rotation.y < -limit)
        {
            transform.rotation = new Quaternion(transform.rotation.x, -limit, transform.rotation.z, transform.rotation.w);
        }

        PlayerMesh.transform.Rotate(moveVertical * Vector3.right * 2);
        if (PlayerMesh.transform.rotation.x > 0 && PlayerMesh.transform.rotation.x > limit)
        {
            PlayerMesh.transform.rotation = new Quaternion(limit, PlayerMesh.transform.rotation.y, PlayerMesh.transform.rotation.z, PlayerMesh.transform.rotation.w);
        }
        else if (PlayerMesh.transform.rotation.x < 0 && PlayerMesh.transform.rotation.x < -limit)
        {
            PlayerMesh.transform.rotation = new Quaternion(-limit, PlayerMesh.transform.rotation.y, PlayerMesh.transform.rotation.z, PlayerMesh.transform.rotation.w);
        }

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
