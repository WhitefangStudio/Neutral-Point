using UnityEngine;
using System.Collections;

public class FactoryList : MonoBehaviour {
	public static FactoryList FL;
	Transform[] factories;
	// Use this for initialization
	void Start () {
		factories = new Transform[6];
		if (FL == null) {
			FL=this;
		}
	}
	
	public void setFactory(int position,Transform Factory){
		if (factories [position] == null) {
			factories[position] = Factory;
		}
	}
	public Transform getFactory(int position){
		if (factories [position] != null) {
			return factories [position];
		} else {
			return null;
		}
	}
}
