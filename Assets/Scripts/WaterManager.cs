using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterManager : MonoBehaviour {

    public static WaterManager shittyInstance = null;

    //public List<GameObject> connectedHallways = new List<GameObject>();
    List<LeakSpawner> leakSpawners = new List<LeakSpawner>();

    public GameObject waterPlanes;
    public GameObject leakPrefab;

    public float waterLevel = 0;
    public float maxRate;
    public float minRate;

    void Awake()
    {
        shittyInstance = this;
    }

	// Use this for initialization
	void Start () {

        leakSpawners = new List<LeakSpawner>(FindObjectsOfType<LeakSpawner>());

        StartCoroutine(SpawnLeaksRoutine());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnLeaksRoutine()
    {
        while (true)
        {
            if (leakSpawners.Count != 0)
            {
                int index = Random.Range(0, leakSpawners.Count);

                CreateLeak(leakSpawners[index]);
            }

            yield return new WaitForSeconds(2);
        }
    }

    public void RemoveLeakSpawner(LeakSpawner leakSpawner)
    {
        leakSpawners.Remove(leakSpawner);
    }

    public void AddLeakSpawner(LeakSpawner leakSpawner)
    {
        leakSpawners.Add(leakSpawner);
    }

    void CreateLeak(LeakSpawner leakSpawner)
    {
        GameObject leakObject = (GameObject) GameObject.Instantiate(leakPrefab);
        leakObject.transform.position = leakSpawner.gameObject.transform.position;
        leakObject.transform.rotation = leakSpawner.gameObject.transform.rotation;

        Leak leakComponent = leakObject.GetComponent<Leak>();

        float rate = Random.Range(minRate, maxRate);

        leakComponent.Initialize(leakSpawner, rate);
    }
}