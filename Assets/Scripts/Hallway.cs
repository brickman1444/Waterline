using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hallway : MonoBehaviour {

    //List<GameObject> adjacentObjects = new List<GameObject>();
    static float gridSize = 4;

    const float epsilon = 0.1f;

	// Use this for initialization
    void Start()
    {
        //adjacentObjects = GetAdjacentHallways(gameObject);
        //WaterManager.shittyInstance.connectedHallways.Add(gameObject);
    }

    private static bool TestDistance(Vector3 a, Vector3 b)
    {
        Vector3 c = b - a;

        return c.sqrMagnitude <= epsilon;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    static List<GameObject> GetAdjacentHallways(GameObject hallway)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(hallway.tag);

        Vector3 myPos = hallway.transform.position;

        List<GameObject> retList = new List<GameObject>();

        foreach (GameObject go in taggedObjects)
        {
            Vector3 otherPos = go.transform.position;

            Vector3 testPos = myPos + Vector3.forward * gridSize;

            if (TestDistance(otherPos, testPos))
            {
                retList.Add(go);
            }

            testPos = myPos + Vector3.back * gridSize;

            if (TestDistance(otherPos, testPos))
            {
                retList.Add(go);
            }

            testPos = myPos + Vector3.right * gridSize;

            if (TestDistance(otherPos, testPos))
            {
                retList.Add(go);
            }

            testPos = myPos + Vector3.left * gridSize;

            if (TestDistance(otherPos, testPos))
            {
                retList.Add(go);
            }
        }

        return retList;
    }
}