using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	GameObject mg;
	// Use this for initialization
	void Start () {
		mg=GameObject.Find ("Test");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void test(){
		mg.GetComponent<WeaponStats> ().Shoot ();
	}
}
