using UnityEngine;
using System.Collections;

public class Slot_Weapon : Slot {
	public PartNavigation.WeapType weapType;

	public string strength;


	
	// Use this for initialization
	public string getStrength(){
		return strength;
	}
	
	public PartNavigation.WeapType getTier3Type(){
		return weapType;
	}

	// Use this for initialization
	void Start () {
		tier2 = (int)slotType;
		Layers = 3;
		base.type = PartNavigation.BaseType.Slot;
		slotType = PartNavigation.SlotType.Weapon;
		tier3 = (int)weapType;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
