using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowErrorMessage : MonoBehaviour {
	/*
	 * Shows an error message to the player.
	 * accessible via static reference.
	 */

	public static ShowErrorMessage SEM;
	Text text;
	// Use this for initialization
	void Awake () {
		if (SEM == null) {
			SEM=this;
		}
		text = GetComponent<Text> ();
		displayError ("Started");

	}
	
	// Update is called once per frame
	void Update () {
	}


	//Displays a string in red for 1.5 seconds
	public void displayError(string Message){
		text.CrossFadeAlpha(1f,0f,false);
		text.color = new Color(.75f, .15f, .15f,100f);
		text.text = Message;
		text.CrossFadeAlpha(0f,1.5f,false);
		
	}
}
