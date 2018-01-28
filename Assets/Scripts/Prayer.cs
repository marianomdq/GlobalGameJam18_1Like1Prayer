using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Prayer : MonoBehaviour {

    private ParticleSystem exp;
    Animator anim;

	// Use this for initialization
	void Start () {
        exp = GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();
        exp.Stop();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            exp.Play();
            other.gameObject.transform.DetachChildren();
            Destroy(other.gameObject);
            anim.SetBool("ChangeImage", true);
            SceneManager.LoadScene("Lvl2");

        }
    }
}
