using UnityEngine;
using System.Collections;

public class Flusher : MonoBehaviour {

    public float startingFlushingTime;
    public float flushingRate;
    public float timeMultiplier;

    private float flushingTime;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        flushingTime = startingFlushingTime;
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
            flushingTime *= timeMultiplier;
        }
    }

    void BeginFlush()
    {
        WaterMover.shittyInstance.rate -= flushingRate;
        renderer.enabled = false;
        audioSource.Play();
    }

    void EndFlush()
    {
        WaterMover.shittyInstance.rate += flushingRate;
        renderer.enabled = true;
        audioSource.Stop();
    }
}
