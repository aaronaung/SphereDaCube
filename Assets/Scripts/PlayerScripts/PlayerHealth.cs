using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	public Slider healthSlider;
	public PlayerMovement movementScript; 
	public PlayerShooting shootScript;
	public Image attackedImage;
	public float imageFlashSpeed = 3f;
	public Color imageFlashColor = new Color(1f, 0f, 0f, 0.1f); //rgb all red. 

	//PLAYER DEATH - GAME LOST variables
	public GameObject restart;
	public Text loseText;

	//STATE Monitoring variables 
	public bool dead;
	public bool attacked; 
	public bool sinking;

	// Use this for initialization
	void Awake () {
		currentHealth = maxHealth;
		movementScript = GetComponent<PlayerMovement> ();
		shootScript = GetComponentInChildren<PlayerShooting> ();
		healthSlider.value = maxHealth;
		dead = false;
		attacked = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (sinking) {
			transform.Translate (Vector3.down * 0.2f * Time.deltaTime);
		}
		if (attacked) {
			attackedImage.color = imageFlashColor;
		} else {
			attackedImage.color = Color.Lerp (attackedImage.color, Color.clear, imageFlashSpeed * Time.deltaTime); 
		} attacked = false; 

		if (dead) {
			restart.SetActive (true);
			loseText.text = "GAME OVER";
			loseText.color = new Color (156, 0, 0);
		}
	}

	public void TakeDamage(int amount){
		attacked = true; 
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if (currentHealth <= 0 && !dead) {
			Death ();
		}
	}

	public void Death(){
		dead = true;
		movementScript.enabled = false;
		shootScript.enabled = false;
		GetComponent<Renderer> ().material.color = Color.black;
		Sinking ();
	}

	//changes color when die and sink
	public void Sinking(){
		GetComponent<Rigidbody> ().isKinematic = true; 
		sinking = true;
		Destroy (gameObject, 4f);
	}
}
