using UnityEngine;
using System.Collections;

public class SlotInfo : MonoBehaviour {
	PartNavigation.WeapType weaponType;
	public string strength;
	public string name;
	Transform[] slots;

	// Use this for initialization
	public string getStrength(){
		return strength;
	}

	public PartNavigation.WeapType getWeaponType(){
		return weaponType;
	}

	public string getName(){
		return name;
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
