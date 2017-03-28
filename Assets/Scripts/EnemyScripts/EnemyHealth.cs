using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int curHealth;
	public float sinkSpeed = 0.5f;
	public int killScore = 10;

	ScoreTracker scoreTracker;
	BoxCollider enemyCollider;
	public bool dead;
	public bool sinking;
	// Use this for initialization
	void Awake () {
		enemyCollider = GetComponent<BoxCollider> ();
		scoreTracker = GameObject.FindGameObjectWithTag ("ScoreTracker").GetComponent<ScoreTracker> ();
		curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		//the enemy will sink when it dies. 
		if (sinking) {
			transform.Translate (Vector3.down * sinkSpeed * Time.deltaTime);
		}
	}

	public void TakeDamage(int amount){
		if (dead) {
			return;	
		}
		curHealth -= amount;
		if (curHealth <= 0) {
			Death ();
		}
	}

	public void Death(){
		dead = true; 
		enemyCollider.isTrigger = true; 
		GetComponent<Renderer> ().material.color = Color.gray; 
		scoreTracker.incScore (killScore);
		Sink ();

	}

	public void Sink(){
		GetComponent<NavMeshAgent>().enabled = false;
		GetComponent<Rigidbody> ().isKinematic = true; 
		sinking = true;
		Destroy (gameObject, 2f);
	}
}
