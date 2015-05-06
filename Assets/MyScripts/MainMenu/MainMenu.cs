using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {


	// Use this for initialization
	public void TestLeve(){
		Application.LoadLevel ("NewUI");
	}
	
	// Update is called once per frame
	public void Exit(){
		Application.Quit ();
	}
}
