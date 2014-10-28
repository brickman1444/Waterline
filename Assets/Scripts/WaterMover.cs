using UnityEngine;
using System.Collections;

public class WaterMover : MonoBehaviour {

    public static WaterMover shittyInstance = null;

    public float minY;
    public float maxY;
    public float rate;

    void Awake()
    {
        shittyInstance = this;
    }

	// Use this for initialization
	void Start () {
        Vector3 pos = transform.position;
        pos.y = minY;
        transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
	    
        Vector3 pos = transform.position;

        pos.y += rate * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.O))
        {
            rate += 1;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            rate -= 1;
        }

        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
	}
}
