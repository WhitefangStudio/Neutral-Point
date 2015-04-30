using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Selected : MonoBehaviour {
	public static Selected selected;
	public List<Transform> selectedUnit;
	// Use this for initialization
	void Start () {
		selected = this;
	}

	public void setGameObject(){
		selectedUnit.Clear ();
		UIPanelManager.Panel.factoryView();
	}

	public void setGameObject(Transform unit){
		selectedUnit.Clear ();
		selectedUnit.Add(unit);
		if (unit.GetComponent<Factory> ()!=null) {
			UIPanelManager.Panel.slotsView(unit.gameObject);
		}
	}

	//public Transform getGameObject(){
		//return selectedUnit;
	//}
	public void addToSelected(Transform unit){
		selectedUnit.Add (unit);
	}

	public int Count(){
		return selectedUnit.Count;
	}
	public Transform getAtPosition(int i){
		return selectedUnit[i];
	}
	public bool isMovable(int i){
		if ((selectedUnit [i].GetComponent<Unit> () != null)&&(selectedUnit[i].GetComponent<Seeker> ()!=null)) {
			return true;
		} else {
			return false;
		}
	}


}
