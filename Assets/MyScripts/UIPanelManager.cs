using UnityEngine;
using System.Collections;

public class UIPanelManager : MonoBehaviour {

	public static UIPanelManager Panel;

	public GameObject Factory;
	public GameObject Slots;

	void Awake(){
		Panel = this;
	}

	// Use this for initialization
	public void slotsView () {
		Factory.SetActive (false);
		Slots.SetActive (true);
	}
	
	// Update is called once per frame
	public void factoryView () {
		Factory.SetActive (true);
		Slots.SetActive (false);
	}
}
