using UnityEngine;
using System.Collections;

public class Name : MonoBehaviour {
	Transform text;
	private bool enterPressed = false;
	public string playerName= "Name";
	Rect position = new Rect (Screen.width/2-50, Screen.height/2-15, 100, 30);
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Return)){
			enterPressed = true;
		}
	}
	
	void OnGUI(){
			if(enterPressed == false){
				playerName = GUI.TextField (position, playerName,25);
			}
	}
	

}
