using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
	public Canvas exitMenu;
	public Button playText;
	public Button exitText;

	// Use this for initialization
	void Start ()
	{
		exitMenu = exitMenu.GetComponent<Canvas> ();
		playText = playText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		StartMenu ();
	}

	public void StartMenu(){
		exitMenu.enabled = false;
		playText.enabled = true;
		exitText.enabled = true;
	}

	public void ExitMenu(){
		exitMenu.enabled = true;
		playText.enabled = false;
		exitText.enabled = false;
	}

	public void BeginLevel(){
		SceneManager.LoadScene ("Level1");
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
