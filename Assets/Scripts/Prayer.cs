using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prayer : MonoBehaviour {

    private ParticleSystem exp;

	// Use this for initialization
	void Start () {
        exp = GetComponent<ParticleSystem>();
        exp.Stop();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            exp.Play();
            Destroy(other.gameObject);
            
        }
    }

    void Explode()
    {
        
    }
}
