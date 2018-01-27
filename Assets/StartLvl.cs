using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLvl : MonoBehaviour {

    public GameObject Animation;
    private Animator Animator;

	// Use this for initialization
	void Start () {
        Animator = Animation.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Animator.SetBool("CamFollowLike", true);
            //SceneManager.LoadScene("Main");
        }
	}

    

}
