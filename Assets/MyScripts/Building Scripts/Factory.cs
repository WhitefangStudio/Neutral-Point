﻿using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour {
	bool selected=false;
	public int player;
	public int position;

	GameObject[] slots;
	public string[] partsList;
	public enum blah {Extractor,Weapon};
	public blah bl;

	// Use this for initialization

	void Start(){
		player =PhotonNetwork.player.ID;

	}
	void OnEnable(){
		slots = new GameObject[7];
		partsList = new string[1];
		partsList [0] = "Extractor";
	}

	void OnMouseUpAsButton(){
		Selected.selected.setGameObject (this.transform);
		Debug.Log ("clicked"+this.transform.ToString());
	}
	// Update is called once per frame
	void Update () {
		/*if (Input.GetMouseButtonDown (0)) {
			if ((Input.mousePosition.y > 190)) {
				selected = false;
				UIPanelManager.Panel.factoryView (position);
			}
		}*/

	}
	public void setPosition(int part,int pos){
		
		slots [pos] = PhotonNetwork.Instantiate (partsList [part], transform.GetChild (pos).position, Quaternion.identity, 0);
		slots [pos].transform.SetParent (this.transform.GetChild(pos));


	}
}
