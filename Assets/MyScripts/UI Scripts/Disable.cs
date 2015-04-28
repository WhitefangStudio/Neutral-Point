using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Disable : MonoBehaviour {
	public InputField dis;
	// Use this for initialization
	void Start (){
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void disable(){
		dis.enabled=false;
		dis.enabled=true;
		//dis.text.enabled = false;
		//dis.text.enabled = true;
	}
}
