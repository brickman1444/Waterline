using UnityEngine;
using System.Collections;

public class Leak : MonoBehaviour {

    public float rate;
    public GameObject hallway;

    const int maxMinEmission = 75;
    const float increaseTime = 0.5f;
    const float increaseLerpPercent = 0.1f;

	// Use this for initialization
	void Start () {
        
	}

    public void Initialize(GameObject _hallway, float _rate)
    {

        rate = _rate;
        hallway = _hallway;

        //Debug.Log(rate);

        UpdateEffects();

        WaterMover.shittyInstance.rate += rate;
    }

    void UpdateEffects()
    {
        float normalizedRate = rate / WaterManager.shittyInstance.maxRate;

        AudioSource audioSource = GetComponentInChildren<AudioSource>();
        audioSource.pitch = normalizedRate * 6 - 3;
        audioSource.volume *= normalizedRate;

        ParticleEmitter emitter = GetComponentInChildren<ParticleEmitter>();

        emitter.minEmission *= normalizedRate;// *maxMinEmission;
        emitter.maxEmission *= normalizedRate;
        emitter.minSize *= normalizedRate;
        emitter.maxSize *= normalizedRate;
    }

	// Update is called once per frame
	void Update () {

	}

    IEnumerator RateIncreaserRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseTime);

            WaterMover.shittyInstance.rate -= rate; // subtract old rate
            rate += (WaterManager.shittyInstance.maxRate - rate) * increaseLerpPercent;
            WaterMover.shittyInstance.rate += rate; // add in new rate
            UpdateEffects();
        }
    }

    void OnDestroy()
    {
        WaterMover.shittyInstance.rate -= rate;
    }
}
