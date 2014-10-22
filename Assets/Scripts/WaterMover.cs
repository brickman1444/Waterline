using UnityEngine;
using System.Collections;

public class WaterMover : MonoBehaviour {

    public float minY;
    public float maxY;
    public float speed;

	// Use this for initialization
	void Start () {
        Vector3 pos = transform.position;
        pos.y = minY;
        transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
	    
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.O))
        {
            pos.y += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.P))
        {
            pos.y -= speed * Time.deltaTime;
        }

        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
	}
}
