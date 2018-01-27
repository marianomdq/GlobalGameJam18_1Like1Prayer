using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSpin : MonoBehaviour {

    private Vector3 v3;

	// Use this for initialization
	void Start () {
        v3 = new Vector3(Random.Range(0.01f, 0.5f), 0.2f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(v3);
    }
}
