using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
	public int bulletDamage = 20;
	public float shootFrequency = 0.15f;
	public float range = 100f;

	float timer; //attack when the time is right
	Ray bulletRay = new Ray();
	RaycastHit rayHit;
	int shootableMask;
	LineRenderer bulletLine;
	Light gunLight;
	float effectsDisplayTime = 0.2f;

	// Use this for initialization
	void Awake () {
		shootableMask = LayerMask.GetMask ("Shootable");
		gunLight = GetComponent<Light> ();
		bulletLine = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime; //keep track of time until it hits the time between each attack (shootFrequency)
		if (Input.GetButton ("Fire1") && timer >= shootFrequency) {
			Fire ();
		}
		if (timer >= (shootFrequency * effectsDisplayTime) && bulletLine != null && gunLight != null ){
			RemoveEffects ();
		}
	}

	public void RemoveEffects(){
		gunLight.enabled = false; 
		bulletLine.enabled = false;
	}

	void Fire(){
		timer = 0f; 
		if (gunLight != null && bulletLine != null) {
			gunLight.enabled = true;
			bulletLine.enabled = true;
			bulletLine.SetPosition (0, transform.position);

			//Ray origin is set to the tip of the cannon, and the direction will be in z 
			bulletRay.origin = transform.position;
			bulletRay.direction = transform.forward; 

			if (Physics.Raycast (bulletRay, out rayHit, range, shootableMask)) {
				//get the enemyscript frm the collider that gets hit by the ray
				//if the enemyscript is null then the ray fails to hit enemy
				EnemyHealth enemyHealthScript = rayHit.collider.GetComponent<EnemyHealth> ();
				if (enemyHealthScript != null) {
					enemyHealthScript.TakeDamage (bulletDamage);
				}
				//Line renderers have elements - index 0 is starting point index 1 is ending point. 
				bulletLine.SetPosition (1, rayHit.point);
			} else {
				//if didn't hit anything, let the bullet travel in the direction at a given range.
				bulletLine.SetPosition (1, bulletRay.origin + bulletRay.direction * range); 
			}
		}
	}
}
