using UnityEngine;
using System.Collections;

public class Weapon: Photon.MonoBehaviour {
	GameObject weapon;
	public GameObject weap;  //Drag "weap" here in the Inspector
	
	// Use this for initialization
	void Start () {
		photonView.RPC("InstantiateGun",PhotonTargets.All);
	}
	
	// Update is called once per frame
	
	[RPC] void InstantiateGun (){
		weapon = (GameObject)Instantiate(weap, transform.position, transform.rotation);
		Vector3 newY = weapon.transform.position;
		newY.y+=1.5f;
		weapon.transform.position= newY;
		
		//this is the part that is giving me trouble.
		weapon.transform.parent=transform;
		//fire.transform.parent = myGuy.transform;
	}
}