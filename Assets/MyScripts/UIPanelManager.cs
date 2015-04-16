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
	public void slotsView (GameObject factory) {
		Factory.SetActive (false);
		Slots.SetActive (true);
		Slots.GetComponent<FactoryButtons> ().setPosition (factory);
	}
	
	// Update is called once per frame
	public void factoryView () {
		Factory.SetActive (true);
		Slots.SetActive (false);
	}
}
