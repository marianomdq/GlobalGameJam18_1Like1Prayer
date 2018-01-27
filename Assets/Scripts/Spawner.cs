using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] Segments;
    public GameObject CurrentSegment;
    public GameObject TubeContainer;

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

    public void Spawn(GameObject newCurrentSegment)
    {
        GameObject LastSegment = CurrentSegment;
        CurrentSegment = newCurrentSegment;

        Vector3 SpawningPosition = newCurrentSegment.GetComponent<Segment>().SpawningAnchor.transform.position;
        Quaternion SpawningRotation = newCurrentSegment.GetComponent<Segment>().SpawningAnchor.transform.rotation;
        int SegmentIndex = Random.Range(0, Segments.Length-1);

        Instantiate(Segments[SegmentIndex], SpawningPosition, SpawningRotation, TubeContainer.transform);

        Destroy(LastSegment);
    }
}
