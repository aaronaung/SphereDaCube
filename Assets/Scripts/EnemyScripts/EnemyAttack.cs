using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float timer;
	public float attackFrequency = 5f;
	public int damage = 10;
	bool inRange;
	PlayerHealth playerHealth;
	GameObject player;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == player) {
			inRange = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player) {
			inRange = false;
		}
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= attackFrequency && inRange) {
			AttackPlayer ();
		}
	}

	void AttackPlayer(){
		timer = 0f;
		if (playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage (damage);
		}
	}
}
