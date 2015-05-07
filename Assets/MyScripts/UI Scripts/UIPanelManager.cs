using UnityEngine;
using System.Collections;

public class UIPanelManager : MonoBehaviour {
	/*
	 * Switches between the Factory editor and the unit selection panels
	 * 
	 */

	//stastic reference so this is accessible anywhere
	public static UIPanelManager Panel;

	//references to respective panels, dragged manually via inspector
	public GameObject Factory;
	public GameObject Slots;

	//enumeration to decide which view is being displayed
	enum view{Factory,Slots}
	new view v=view.Slots;

	//delay timer to match up with shutter animations
	float timer=0;

	void Awake(){
		Panel = this;
	}

	// Use this for initialization
	public void slotsView (GameObject factory) {
		if (v != view.Slots) {
			Shutter.shutter.toggleShutterAnim ();
			Shutter.shutter.shutterOther();
			v = view.Slots;
			timer = 0;
		}
	}
	
	// Update is called once per frame
	public void factoryView () {
		if (v != view.Factory) {
			Shutter.shutter.toggleShutterAnim ();
			Shutter.shutter.shutterOther();
			v = view.Factory;
			timer = 0;
		}
	}

	void Update(){
		if(timer<1){
			timer+=Time.deltaTime*5;
		}
		if (timer >= 1) {
			if(v==view.Factory){
				Factory.SetActive (true);
				Slots.SetActive (false);
			}
			if(v==view.Slots){
				Factory.SetActive (false);
				Slots.SetActive (true);
			}

		}

	}
}
