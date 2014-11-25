using UnityEngine;
using System.Collections;

public class GUITextureFillScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float width = Screen.width;
        float height = Screen.height;

        guiTexture.pixelInset.Set(-width, -height, width, height);
	}
}
