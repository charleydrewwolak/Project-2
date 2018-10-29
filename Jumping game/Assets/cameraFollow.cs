using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public Transform target;
    public Transform destroyerPos;
    public float smoothSpeed = .3f;

    private void Start()
    {
        Vector3 destroyerPos = new Vector3(transform.position.x - 1, transform.position.y - 1);
    }

    // Update is called once per frame
    void LateUpdate () {
		if (target.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPos;
        }
	}
}
