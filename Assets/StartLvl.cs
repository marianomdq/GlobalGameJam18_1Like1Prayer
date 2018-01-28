using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLvl : MonoBehaviour {

    public GameObject cam, like;
    private Animator animLike,animCam;

	// Use this for initialization
	void Start () {
        animLike = like.GetComponent<Animator>();
        animCam = cam.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            animLike.SetBool("Clicked", true);
            animCam.SetBool("CamFollowLike", true);
            SceneManager.LoadScene("Main");
        }
	}

}
