using UnityEngine;
using System.Collections;

public class Weapon: Photon.MonoBehaviour {

	public Transform[] nodes;
	
	// Use this for initialization
	public void AddPart (string weapon,int pos) {
		GameObject newWeap=(GameObject)PhotonNetwork.Instantiate (weapon, nodes [pos].position, nodes [pos].rotation, 0);
		newWeap.transform.parent=nodes[pos];
	}

	public Transform[] getWeaponList(){
		return nodes;
	}
	public void setTarget(Transform target){
		GetComponent<UnitStats> ().setTarget (target);
		foreach(Transform node in nodes){
			if(node.GetComponentInChildren<WeaponStats>()!=null){
				node.GetComponentInChildren<WeaponStats>().setTarget(target);
			}
		}
	}
	
	// Update is called once per frame

}