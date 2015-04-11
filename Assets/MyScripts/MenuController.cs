using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	bool menuOpened;

	// Use this for initialization
	public GameObject panel;
	void Awake () {
		panel.SetActive (false);
		menuOpened = false;
	}
	
	public void Enable(){
		panel.SetActive (true);
		CameraMovement.Cam.camLock = true;
		menuOpened = true;
	}

	public void Disable(){
		panel.SetActive (false);
		CameraMovement.Cam.camLock = false;
		menuOpened = false;
	}

	public void GoToMainMenut(){
		Application.LoadLevel ("Main Menu");
	}

	public void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
		  if(menuOpened==false){
			Enable ();
			}else{
			Disable();
			}
		}
	}
}
