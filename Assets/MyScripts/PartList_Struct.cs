using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartList_Struct: MonoBehaviour {
	public ArrayList part;
	string Name;

	public void ParList_Struct(){
		part = new ArrayList ();
	}

	public void add<T>(T param){
		part.Add (param);
	}
	public void setName(string name){
		Name = name;
	}
	public string getName(){
		return name;
	}

}