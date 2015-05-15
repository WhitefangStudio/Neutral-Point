using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FactoryPart : MonoBehaviour {
	public GameObject correspondingAttachment;
	public string name;
	protected int Layers;
	public int tier2;
	public int tier3;
	public PartNavigation.BaseType type;
	int pairNum;

	public List <GameObject> pair;

	// Use this for initialization
	protected void initialize(){
		type = PartNavigation.BaseType.Nothing;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public PartNavigation.BaseType getBaseType(){
		return this.type;
	}

	public int getTier3Int(){
		return tier3;
	}
	
	public int getTier2Int(){
		return tier2;
	}
	public int getLayers(){
		return Layers;
	}
	public string getName(){
		return name;
	}

	public bool hasPair(){
		if (pair.Count>0) {
			return true;
		} else {
			return false;
		}
	}
	public int getTier(int i){
		if (i == 1) {
			return getTier2Int ();
		} else if (i == 2) {
			return getTier3Int ();
		} else {
			return -1;
		}
	}

	public void addToPair(GameObject pair){
		this.pair.Add (pair);
	}
}
