using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereScript : MonoBehaviour {
	GameObject player;
	Text winGame;
	public GameObject restart;
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		winGame = GameObject.Find ("HUDCanvas/WinState").GetComponent<Text>();
		restart = GameObject.Find ("HUDCanvas").transform.Find("Restart").gameObject;
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		if (other.gameObject == player) {
			winGame.text = "GAME WON";
			winGame.fontSize = 65;
			winGame.color = new Color (0.44f, 1f, 0.86f);
			restart.SetActive (true);

			GameObject[] allEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (GameObject enemy in allEnemies) {
				EnemyHealth health = enemy.GetComponent<EnemyHealth>();
				health.Death ();
				player.GetComponent<PlayerMovement> ().enabled = false;
				player.GetComponent<PlayerShooting> ().enabled = false;
			};
		}
	}

}
