using UnityEngine;
using System.Collections;

public class LeakSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        Debug.LogError("leak spawner destroyed");
    }
}
