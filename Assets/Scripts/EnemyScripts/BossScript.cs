using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

	EnemyHealth bossHealth;
	public GameObject smallerBoss;
	public int numOfSmallBosses = 10; 
	public GameObject Sphere;
	bool nowSpawn = true; 

	// Use this for initialization
	void Awake () {
		bossHealth = GetComponent<EnemyHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (bossHealth.dead && nowSpawn) {
			Instantiate (Sphere, transform.position, transform.rotation);
			SpawnSmallerBosses ();
		}
	}

	void SpawnSmallerBosses(){
		for (int i = 0; i < numOfSmallBosses; i++) {
			Instantiate (smallerBoss, transform.position, transform.rotation);
		}
		nowSpawn = false; 
	}

	void SpawnDoor(){
		Sphere.SetActive (true);
	}
}
