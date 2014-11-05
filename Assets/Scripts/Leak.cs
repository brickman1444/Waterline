using UnityEngine;
using System.Collections;

public class Leak : MonoBehaviour {

    public float rate;
    public GameObject hallway;

    const int maxMinEmission = 75;

	// Use this for initialization
	void Start () {
        
	}

    public void Initialize(GameObject _hallway, float _rate)
    {

        rate = _rate;
        hallway = _hallway;

        Debug.Log(rate);

        float normalizedRate = rate / WaterManager.shittyInstance.maxRate;

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.pitch = normalizedRate * 6 - 3;
        audioSource.volume *= normalizedRate;

        ParticleEmitter emitter = GetComponentInChildren<ParticleEmitter>();

        emitter.minEmission *= normalizedRate;// *maxMinEmission;
        emitter.maxEmission *= normalizedRate;
        emitter.minSize *= normalizedRate;
        emitter.maxSize *= normalizedRate;

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
