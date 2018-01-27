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
            Invoke("ChangeLevel", 4.0F);
        }
    }

    void ChangeLevel()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Main":
                SceneManager.LoadScene("Menu2");
                break;
            case "Level2":
                SceneManager.LoadScene("Menu3");
                break;
            case "Level3":
                SceneManager.LoadScene("Victory");
                break;
        }
    }
}
