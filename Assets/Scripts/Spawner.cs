using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] Segments;
    public GameObject CurrentSegment;

    public static Spawner instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawn()
    {
        Vector3 SpawningPosition = CurrentSegment.transform.position;
        Quaternion SpawningRotation = CurrentSegment.transform.rotation;
        int SegmentIndex = Random.Range(0, Segments.Length-1);

        Instantiate(Segments[SegmentIndex], SpawningPosition, SpawningRotation);




    }
}
