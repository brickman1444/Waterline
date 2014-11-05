using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {

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

            if (Physics.Raycast(ray, out outHitInfo, 2.5f, 1 << 8))
            {
                Destroy(outHitInfo.collider.gameObject);
                Debug.Log("Hit!");
            }
            else
            {
                Debug.Log("Miss!");
            }
        }
	}
}
