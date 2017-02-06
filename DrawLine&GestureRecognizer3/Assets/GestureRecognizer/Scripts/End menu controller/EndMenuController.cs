using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndMenuController : MonoBehaviour {

	public void OnClickTryAgainButton()
	{
		SceneManager.LoadScene("Recognize"); 

	}

}
