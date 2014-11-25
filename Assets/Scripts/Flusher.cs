using UnityEngine;
using System.Collections;

public class Flusher : MonoBehaviour {

    public float startingFlushingTime;
    public float flushingRate;
    public float timeMultiplier;
    public GameObject enabledVisual;
    public GameObject disabledVisual;
    public GameObject lightObject;

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
        audioSource.Play();
        enabledVisual.SetActive(false);
        disabledVisual.SetActive(true);
        lightObject.SetActive(false);
    }

    void EndFlush()
    {
        WaterMover.shittyInstance.rate += flushingRate;
        audioSource.Stop();
        enabledVisual.SetActive(true);
        disabledVisual.SetActive(false);
        lightObject.SetActive(true);
    }
}
