using UnityEngine;
using System.Collections;

public class PopFromSide : MonoBehaviour {
	public enum side{Left,Top,Right,Bottom};
	public side sideToPop;
	
	public bool hide = false;
	// Use this for initialization

	public void showPanel(){
		hide = false;
		GetComponent<Animator> ().SetBool ("Hidden", false);
	}

	public void hidePanel(){
		hide =true;
		GetComponent<Animator> ().SetBool ("Hidden", true);

	}
	void start(){
		GetComponent<Animator> ().SetBool ("Hidden", true);
	}
}
