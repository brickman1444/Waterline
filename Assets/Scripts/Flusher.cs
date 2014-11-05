using UnityEngine;
using System.Collections;

public class Flusher : MonoBehaviour {

    public float flushingTime;
    public float flushingRate;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
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
        audioSource.Play();
    }

    void EndFlush()
    {
        WaterMover.shittyInstance.rate += flushingRate;
        renderer.enabled = true;
        audioSource.Stop();
    }
}
