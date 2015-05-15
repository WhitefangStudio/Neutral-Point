using UnityEngine;
using System.Collections;

public class Slot_Toggle : Slot {
	public PartNavigation.WeapType weapType;
	
	public string strength;
	
	// Use this for initialization
	public string getStrength(){
		return strength;
	}
	
	public PartNavigation.WeapType getTier3Type(){
		return weapType;
	}
	
	public string getName(){
		return name;
	}
	
	// Use this for initialization
	void Start () {
		Layers = 3;
		base.type = PartNavigation.BaseType.Slot;
		slotType = PartNavigation.SlotType.Toggle;
		tier2 = (int)slotType;
		tier3 = (int)weapType;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
