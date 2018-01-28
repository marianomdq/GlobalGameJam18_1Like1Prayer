using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour {

    public Transform SpawningAnchor;

    private bool alreadyActivated = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && !alreadyActivated)
        {
            alreadyActivated = true;
            Spawner.instance.Spawn(this.gameObject);
        }
    }
}
