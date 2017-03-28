using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour {

	// Use this for initialization
	public int speed;
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector2.up, speed * Time.deltaTime);
	}
}
