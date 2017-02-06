using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class MainMenuController : MonoBehaviour {

	public void OnClickPlayButton()
	{
		SceneManager.LoadScene("Recognize"); 

	}
}
