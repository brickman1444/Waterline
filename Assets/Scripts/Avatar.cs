﻿using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {

    float reachLength = 3f;
    public GameObject bubbleGumPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            Ray ray = new Ray();
            ray.origin = Camera.main.transform.position;
            ray.direction = Camera.main.transform.forward;

            RaycastHit outHitInfo;

            if (Physics.Raycast(ray, out outHitInfo, reachLength, 1 << 8))
            {
                GameObject gum = (GameObject)Instantiate(bubbleGumPrefab);
                Transform waterFountainTransform = (Transform)outHitInfo.collider.gameObject.GetComponentInChildren<ParticleRenderer>().gameObject.transform;
                gum.transform.position = waterFountainTransform.position;
                //bandaid.transform.forward = -waterFountainTransform.up;
                //bandaid.transform.LookAt(transform);
                //bandaid.transform.rotation = waterFountainTransform.rotation;
                //bandaid.transform.Translate(-waterFountainTransform.up * -.4f);
                Destroy(outHitInfo.collider.gameObject);
                Debug.Log("Hit leak");
            }

            if (Physics.Raycast(ray, out outHitInfo, reachLength, 1 << 9))
            {
                Flusher flush = outHitInfo.collider.gameObject.GetComponent<Flusher>();
                flush.Flush();
                Debug.Log("Hit button");
            }
        }
	}
}
