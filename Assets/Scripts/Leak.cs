using UnityEngine;
using System.Collections;

public class Leak : MonoBehaviour {

    public float rate;

    const int maxMinEmission = 75;
    const float increaseTime = 2f;
    const float increaseLerpPercent = 0.1f;
    public GameObject bubbleGumPrefab;

    LeakSpawner leakSpawner;

	// Use this for initialization
	void Start () {
        
	}

    public void Initialize(LeakSpawner _leakSpawner, float _rate)
    {

        rate = _rate;
        leakSpawner = _leakSpawner;

        WaterManager.shittyInstance.RemoveLeakSpawner(leakSpawner);

        //Debug.Log(rate);

        StartCoroutine(RateIncreaserRoutine());

        UpdateEffects();

        WaterMover.shittyInstance.rate += rate;
    }

    void UpdateEffects()
    {
        float normalizedRate = rate / WaterManager.shittyInstance.maxRate;

        if (normalizedRate > 1 || normalizedRate < 0)
        {
            Debug.LogError("Invalid normalized rate");
        }

        normalizedRate = 1; // HACK

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

            float deltaRate = (WaterManager.shittyInstance.maxRate - rate) * increaseLerpPercent;
            rate += deltaRate;
            WaterMover.shittyInstance.rate += deltaRate;
            UpdateEffects();
        }
    }

    public void FillLeak()
    {
        GameObject gum = (GameObject)Instantiate(bubbleGumPrefab);
        gum.transform.position = transform.position;
        gum.GetComponent<GumBlob>().Initialize(leakSpawner);
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        WaterMover.shittyInstance.rate -= rate;
    }
}
