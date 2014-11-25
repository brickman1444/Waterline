using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {

    float reachLength = 3f;

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
                outHitInfo.collider.gameObject.GetComponent<Leak>().FillLeak();

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
