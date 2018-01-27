using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour {

    public GameObject PlayerMesh;

    public float speed;
    public float initialSpeed = 0.02f;
    public float topSpeed = 0.1f;
    public float accelerationRate = 1;
    public float decelerationPenaltyRate = 0.1f;
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
        float rate = decelerationPenaltyRate;
        if (isReverting)
        {
            rate = accelerationRate;
            decelerationLimit = initialSpeed;
        }
        if (speed > decelerationLimit)
        {
            speed = Mathf.Clamp(speed - (speed * rate), decelerationLimit, 1000);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Emoji"))
        {
            Destroy(other.gameObject);
            Decelerate(false);
        }
        else if (other.gameObject.tag.Equals("Obstacle"))
        {
            Destroy(gameObject);
            //Invoke("GameOver", 1.5f);
            GameOver();
        }
        else if (other.gameObject.tag.Equals("SpawningTrigger"))
        {
            // Send the top most parent (Segment script) and this trigger index
            Spawner.instance.Spawn(other.transform.parent.transform.parent.gameObject, other.transform.GetSiblingIndex());
        }
        else if (other.gameObject.tag.Equals("TriggerChase"))
        {
            other.transform.parent.GetComponent<Chaser>().isChaseEnabled = true;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
