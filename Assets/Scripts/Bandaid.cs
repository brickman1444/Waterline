using UnityEngine;
using System.Collections;

public class Bandaid : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Die", 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Die()
    {
        Destroy(gameObject);
    }
}
