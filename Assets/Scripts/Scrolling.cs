using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

    public float speed = 2f;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(gameObject != null)
            transform.position += Vector3.back * speed;
        else
        {
            Debug.Log("Game Over");

        }
            
    }
}
