using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterManager : MonoBehaviour {

    public static WaterManager shittyInstance = null;

    public List<GameObject> hallways = new List<GameObject>();

    public GameObject waterPlanes;

    public float waterLevel = 0;

    void Awake()
    {
        shittyInstance = this;
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}