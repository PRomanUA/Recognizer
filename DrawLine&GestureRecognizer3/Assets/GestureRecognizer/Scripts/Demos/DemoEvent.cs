using UnityEngine;
using UnityEngine.SceneManagement;
using GestureRecognizer;
using UnityEngine.UI;

// !!!: Drag & drop a GestureRecognizer prefab on to the scene first from Prefabs folder!!!
public class DemoEvent : MonoBehaviour
{
	[Tooltip("Messages will show up here")]
	public Text messageArea;
	public Text timerArea;
	public Image task;
	public Sprite envelopeOpen;
	public Sprite circle;
	public Sprite rectangle;
	public Sprite star;
	public Sprite win;
	private string currentImg;
	public float timer;
	private float timeForFigure;
	private bool started;

	void Update () {
		if (timeForFigure > 0) 
		{
			timeForFigure -= Time.deltaTime; 
			timerArea.text = "Time: " + Mathf.RoundToInt(timeForFigure);
		}
		if (timeForFigure <= 0 && started)
		{
			
			timerArea.text = "TIME IS UP!!!!";
			started = false;
			SetMessage ("YOU lOOSE");
			SceneManager.LoadScene ("EndPage");
		}
	}
	// Subscribe your own method to OnRecognition event 
	void OnEnable()
	{
		GestureBehaviour.OnGestureRecognition += OnGestureRecognition;
		//Image taskImage = task.GetComponent<Image> ();
		started 		= true;
		currentImg 		= "";
		SetNextImg(currentImg);
	}

	// Unsubscribe when this game object or monobehaviour is disabled.
	// If you don't unsubscribe, this will give an error.
	void OnDisable()
	{
		GestureBehaviour.OnGestureRecognition -= OnGestureRecognition;
	}

	// Unsubscribe when this game object or monobehaviour is destroyed.
	// If you don't unsubscribe, this will give an error.
	void OnDestroy()
	{
		GestureBehaviour.OnGestureRecognition -= OnGestureRecognition;
	}


	void OnGestureRecognition(Gesture g, Result r)
	{
		string msg = "Gesture is recognized as <color=#ff0000>'" + r.Name + "'</color> with a score of " + r.Score;
		if (r.Name.Equals(currentImg))
			{msg = "You are right! "+msg;
			SetMessage(msg);
			SetNextImg (r.Name);
			}
		else
			{msg = "Kepp trying! ";
			SetMessage(msg);}



	}

	/// <summary>
	/// Shows a message at the bottom of the screen
	/// </summary>
	/// <param name="text">Text to show</param>
	public void SetMessage(string text)
	{
		messageArea.text = text;
	}

	private void SetNextImg (string imgName)
	{
		Sprite nextTask;

		if (imgName.Equals ("rectangle")) {
			nextTask = envelopeOpen;
			currentImg = "envelop_open";
		} else if (imgName.Equals ("envelop_open")) {
			nextTask = star;
			currentImg = "star";
		} else if (imgName.Equals ("star")) {
			nextTask = circle;
			currentImg = "circle";
		} else if (imgName.Equals ("circle")) {
			SetMessage ("YOU WIN!");
			timerArea.text = "";
			timeForFigure	= 0;
			started = false;
			nextTask = win;
			SceneManager.LoadScene ("EndPage");

		} else { //(imgName.Equals(" "))
			nextTask = rectangle;
			currentImg = "rectangle";
		}


		// set next image 
		task.sprite = nextTask;

		// new time for paint
		if (timeForFigure <= 0) {
			timeForFigure = timer;
		} 
		else
		{	timer = timer - 2;
			timeForFigure = timer;
	
		}

	}
}
