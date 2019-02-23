using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void newGameButton(string newGameLevel)
	{
		SceneManager.LoadScene(newGameLevel);

	}

	public void exitGameButton()
	{
		Application.Quit ();
	}
}
