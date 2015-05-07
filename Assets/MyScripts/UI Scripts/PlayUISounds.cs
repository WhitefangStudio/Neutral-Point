using UnityEngine;
using System.Collections;

public class PlayUISounds : MonoBehaviour {
	public AudioSource sounds;
	public static PlayUISounds Sounds;

	void Awake(){
		Sounds = this;
		}

	public void click(){
		sounds.Play ();
	}
	public void beep(){

	}
}
