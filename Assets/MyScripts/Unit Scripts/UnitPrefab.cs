using UnityEngine;
using System.Collections;

public class UnitPrefab : MonoBehaviour {
	private string name;
	private GameObject body;
	private GameObject slot1;
	private GameObject slot2;
	private GameObject slot3;
	private GameObject engine;


	public void setBody(GameObject body){
		this.body = body;
	}

	public void setSlot1(GameObject slot1){
		this.slot1 = slot1;
	}

	public void setSlot2(GameObject slot2){
		this.slot2 = slot2;
	}

	public void setSlot3(GameObject slot3){
		this.slot3 = slot3;
	}

	public void setEngine(GameObject engine){
		this.engine = engine;
	}

	public void setName(string name){
		this.name = name;
	}

	public GameObject getBody(){
		return this.body;
	}
	
	public GameObject getSlot1(){
		return this.slot1;
	}
	
	public GameObject getSlot2(){
		return this.slot2;
	}

	public GameObject getSlot3(){
		return this.slot3;
	}
	
	public GameObject getEngine(){
		return this.engine;
	}
	
	public string getName(){
		return this.name;
	}
	public void reset(){
		//this.body = null;
		//this.slot1 = null;
		//this.slot2 = null;
		//this.engine = null;
	}

}
