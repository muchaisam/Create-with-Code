using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0 ;
    public float ringsDistance = 5;
    public int numberOfRings = 7;
    public GameObject lastRing;

    void Start()
    {
        //spawn helix rings
        for (int i = 0; i < numberOfRings; i++)
        {
            if (i == 0)
                SpawnRing(0);
            else
                SpawnRing(Random.Range(0, helixRings.Length - 1)); 
        }
        //spawn the last ring
        SpawnRing(helixRings.Length - 1);
    }

    // Update is called once per frame
    public void SpawnRing(int ringIndex)
    {
        GameObject go = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= ringsDistance;
        
    }
}
