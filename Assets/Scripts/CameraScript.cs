using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	Vector3 camOffset;
	public Transform target;
	public float smoothing;
	public float lowBound;

	// Use this for initialization
	void Start () {
		camOffset = transform.position - target.position;
		lowBound = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			Vector3 targetCamPos = target.position + camOffset;
			transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
		}
		if (transform.position.y < lowBound) {
			transform.position = new Vector3 (transform.position.x, lowBound, transform.position.z);
		}
	}
}
