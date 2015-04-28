using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalStats : MonoBehaviour {
	int seconds;
	int minutes;
	int P1Resource;
	int P2Resource;
	Text ResourceDisplay;
	Text time;
	public bool gameStarted;
	public static GlobalStats stats;
	int timer;
	// Use this for initialization
	void OnEnable () {
			if (stats == null) {
				stats = this;
		} 
	}

	void Start(){
		gameStarted = false;
		timer = 0;
		InvokeRepeating ("timerF", 0, 1f);
	}
	// Update is called once per frame
	public void gain(int p){
		if (gameStarted == true) {
			if (p == 1) {
				P1Resource++;
			}else if(p==2){
				P2Resource++;
			}
		}
	}
	void timerF(){
		if(gameStarted)
		timer += 1;
	}

	public void startGame(){
		gameStarted = true;
		Debug.Log ("GameStarted");
		Debug.Log (gameStarted);
	}

	public int getStats(int p){
		if (p == 1) {
			return P1Resource;
		} else if (p == 2) {
			return P2Resource;
		} else {
			return 0;
		}
	}
	public float getTime(){
		return timer;
	}
}
