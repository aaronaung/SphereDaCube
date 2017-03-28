using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	public GameObject player;
	public GameObject enemy;
	public GameObject finalBoss;

	public float spawnTime = 1.5f;
	public float startSpawn = 1f;
	public Transform[] spawnPoints;
	private int randSpawnPoint;
	// Use this for initialization
	bool spawnBoss;
	PlayerHealth playerHealth;
	ScoreTracker scoreScript;

	void Awake(){
		playerHealth = player.GetComponent<PlayerHealth> ();
		scoreScript = GameObject.FindGameObjectWithTag ("ScoreTracker").GetComponent<ScoreTracker> ();
		randSpawnPoint = 0;
		spawnBoss = true;
	}

	void Start () {
		InvokeRepeating ("SpawnPawns", startSpawn, spawnTime);
	}
	
	// Update is called once per frame
	void Update(){
		randSpawnPoint = Random.Range (0, spawnPoints.Length);
		if (scoreScript.playerScore >= 200 & spawnBoss) {
			CancelInvoke ();
			SpawnBoss();
		}
	}

	void SpawnPawns () {
		if (playerHealth.currentHealth <= 0f) {
			return;
		}
		Instantiate (enemy, spawnPoints [randSpawnPoint].position, spawnPoints [randSpawnPoint].rotation);
	}

	void SpawnBoss(){
		if (playerHealth.currentHealth <= 0f) {
			return;
		}
		Instantiate(finalBoss, spawnPoints [randSpawnPoint].position, spawnPoints [randSpawnPoint].rotation);
		spawnBoss = false; 
	}
}
