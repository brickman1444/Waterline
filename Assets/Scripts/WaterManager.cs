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
        float waitTime = 2;
        float percenDecrease = 0.99f;

        while (true)
        {
            if (leakSpawners.Count != 0)
            {
                int index = Random.Range(0, leakSpawners.Count);

                LeakSpawner lastOne = leakSpawners[leakSpawners.Count - 1];

                if (leakSpawners[index] != null)
                {
                    CreateLeak(leakSpawners[index]);
                }
                else
                {
                    Debug.LogError("leak spawning error");
                }
            }

            yield return new WaitForSeconds(waitTime);
            waitTime *= percenDecrease;
        }
    }

    public void RemoveLeakSpawner(LeakSpawner leakSpawner)
    {
        leakSpawners.Remove(leakSpawner);
        Debug.Log("Leak Spawner remove Count: " + leakSpawners.Count);
    }

    public void AddLeakSpawner(LeakSpawner leakSpawner)
    {
        if (leakSpawner == null)
            Debug.LogError("Trying to add null leakspawner");
        leakSpawners.Add(leakSpawner);
        Debug.Log("Leak Spawner added Count: " + leakSpawners.Count);
    }

    void CreateLeak(LeakSpawner leakSpawner)
    {
        GameObject leakObject = (GameObject) GameObject.Instantiate(leakPrefab);
        leakObject.transform.position = leakSpawner.gameObject.transform.position;
        leakObject.transform.rotation = leakSpawner.gameObject.transform.rotation;

        Leak leakComponent = leakObject.GetComponent<Leak>();

        float rate;
       // rate = Random.Range(minRate, maxRate);
        rate = maxRate; // hack

        leakComponent.Initialize(leakSpawner, rate);
    }
}