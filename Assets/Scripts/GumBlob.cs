using UnityEngine;
using System.Collections;

public class GumBlob : MonoBehaviour {

    LeakSpawner leakSpawner;

	// Use this for initialization
	void Start () {
	
	}

    public void Initialize(LeakSpawner _leakSpawner)
    {
        Invoke("Die", 3);
    }

    void Die()
    {
        WaterManager.shittyInstance.AddLeakSpawner(leakSpawner);
        DestroyObject(gameObject);
    }
}
