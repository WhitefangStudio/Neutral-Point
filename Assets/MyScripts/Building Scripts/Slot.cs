using UnityEngine;
using System.Collections;

public class Slot : FactoryPart {
	protected PartNavigation.SlotType slotType;

	// Use this for initialization

	public PartNavigation.SlotType getTier2Type(){
		return slotType;
	}

	public string getName(){
		return name;
	}
	

	// Update is called once per frame
	void Update () {
	
	}


}
