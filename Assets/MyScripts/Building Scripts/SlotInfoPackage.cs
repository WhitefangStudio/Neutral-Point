using UnityEngine;
using System.Collections;

public class SlotInfoPackage : MonoBehaviour {
	public PartNavigation.WeapType weaponType;
	public string name;
	Transform[] slots;

	// Use this for initialization

	public PartNavigation.WeapType getWeaponType(){
		return weaponType;
	}

	public string getName(){
		return name;
	}

	void Start () {
		slots = new Transform[3];
		for (int i =0; i<slots.Length; i++) {
			slots[i]=transform.GetChild(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
