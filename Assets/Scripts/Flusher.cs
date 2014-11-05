using UnityEngine;
using System.Collections;

public class Flusher : MonoBehaviour {

    public float flushingTime;
    public float flushingRate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    const string FlushString = "EndFlush";

    public void Flush()
    {
        if (!IsInvoking(FlushString))
        {
            BeginFlush();
            Invoke(FlushString, flushingTime);
        }
    }

    void BeginFlush()
    {
        WaterMover.shittyInstance.rate -= flushingRate;
        renderer.enabled = false;
    }

    void EndFlush()
    {
        WaterMover.shittyInstance.rate += flushingRate;
        renderer.enabled = true;
    }
}
