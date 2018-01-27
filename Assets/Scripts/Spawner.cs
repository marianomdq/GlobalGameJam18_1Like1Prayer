using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] Segments;
    public GameObject CurrentSegment;
    public GameObject TubeContainer;
    public GameObject finalpost;
    public int maxlvl;
    int i = 0;

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

    public void Spawn(GameObject newCurrentSegment, int SpawningIndex)
    {

        GameObject LastSegment = CurrentSegment;
        CurrentSegment = newCurrentSegment;

        Segment segment = newCurrentSegment.GetComponent<Segment>();

        Vector3 SpawningPosition = segment.SpawningAnchors[SpawningIndex].transform.position;
        Quaternion SpawningRotation = segment.SpawningAnchors[SpawningIndex].transform.rotation;

        if (i < maxlvl)
        {
            int SegmentIndex = Random.Range(0, Segments.Length);

            Instantiate(Segments[SegmentIndex], SpawningPosition, SpawningRotation, TubeContainer.transform);

            Destroy(LastSegment);
            i++;
        }
        else
        {
            Instantiate(finalpost, SpawningPosition, SpawningRotation, TubeContainer.transform);
        }
    }
}
