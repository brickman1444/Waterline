using UnityEngine;
using System.Collections;

public class ScreenLock : MonoBehaviour {

    public bool lockCursor = true;

	// Use this for initialization
	void Start () {
        Screen.lockCursor = lockCursor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
