using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterManager : MonoBehaviour {

    public static WaterManager shittyInstance = null;

    public List<GameObject> connectedHallways = new List<GameObject>();

    public GameObject waterPlanes;
    public GameObject leakPrefab;

    public float waterLevel = 0;
    public float maxRate;

    void Awake()
    {
        shittyInstance = this;
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnLeaksRoutine());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnLeaksRoutine()
    {
        while (true)
        {
            int index = Random.Range(0, connectedHallways.Count);

            GameObject randomHallway = connectedHallways[index];

            CreateLeak(randomHallway);

            yield return new WaitForSeconds(2);
        }
    }

    void CreateLeak(GameObject hallway)
    {
        GameObject leakObject = (GameObject) GameObject.Instantiate(leakPrefab);
        leakObject.transform.position = hallway.transform.position;
        leakObject.transform.rotation = hallway.transform.rotation;

        Leak leakComponent = leakObject.GetComponent<Leak>();

        float rate = Random.Range(0.001f, maxRate);

        leakComponent.Initialize(hallway, rate);
    }
}