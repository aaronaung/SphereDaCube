using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	GameObject player; 
	NavMeshAgent nav;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	// Use this for initialization
	void Awake () {
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		enemyHealth = gameObject.GetComponent<EnemyHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		//have the navmeshagent follow the player.
		if (!playerHealth.dead && !enemyHealth.dead)
			nav.SetDestination (player.transform.position);
		else
			nav.enabled = false;
	}
}
