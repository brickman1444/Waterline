using UnityEngine;
using System.Collections;

public class CameraTinter : MonoBehaviour {

    public GameObject waters;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (waters.transform.position.y >= Camera.main.transform.position.y)
        {
            guiTexture.enabled = true;
        }
        else
        {
            guiTexture.enabled = false;
        }
	}
}
