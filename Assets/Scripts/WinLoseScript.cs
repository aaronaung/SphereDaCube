using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinLoseScript : MonoBehaviour {
	public void Restart(){
		SceneManager.LoadScene ("Level1");
	}
}
