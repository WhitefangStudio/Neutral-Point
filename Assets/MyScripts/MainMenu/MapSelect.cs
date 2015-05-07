using UnityEngine;
using System.Collections;

public class MapSelect : MonoBehaviour {
	public Transform planet1;
	public PlanetsRotate PR;
	bool b=false;
	// Use this for initialization
	void Start () {
	
	}
	public void goToP1(){
		b = true;
		PR.radius = 15;
		PR.Sun=planet1;
	}

	// Update is called once per frame
	void Update () {
		if (b == true) {
			transform.position=Vector3.Lerp (transform.position,planet1.position,Time.deltaTime);
			if(Vector3.Distance(transform.position,planet1.position)<15){
				b=false;
				transform.parent=planet1;
				PR.setup();
			}
		}
	}
}
