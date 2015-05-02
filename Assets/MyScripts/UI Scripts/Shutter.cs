using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shutter : MonoBehaviour {
	public static Shutter shutter;
	Animator left;
	Animator right;
	// Use this for initialization
	void Start () {
		shutter = this;
		left = transform.GetChild (0).GetComponent<Animator> ();
		right = transform.GetChild (1).GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	public void toggleShutterAnim(){
		transform.GetComponent<Image> ().enabled = true;
		left.ResetTrigger ("Shutter");
		left.SetTrigger ("Shutter");
		right.ResetTrigger ("Shutter");
		right.SetTrigger ("Shutter");
	}
}
