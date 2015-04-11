using UnityEngine;
using System.Collections;

public class Extractor : MonoBehaviour {
	public bool isAlive=true;
	public int player;
	int health;
	// Use this for initialization
	void Start () {
		health = 100;
		InvokeRepeating("AddResource", 0,0.5f);
	}
	
	// Update is called once per frame
	void AddResource () {
		if (isAlive) {
			if(GlobalStats.stats!=null){
				GlobalStats.stats.gain (player);
			}
		} else {
			CancelInvoke();
		}
	}

	void Update(){
		if (health <= 0) {
			isAlive=false;
		}
	}
}
