using UnityEngine;
using System.Collections;

public class Leak : MonoBehaviour {

    public float rate;
    public GameObject hallway;

	// Use this for initialization
	void Start () {
        WaterMover.shittyInstance.rate += rate;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnDestroy()
    {
        WaterMover.shittyInstance.rate -= rate;
    }
}
