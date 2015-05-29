using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Selected : MonoBehaviour {
	int player;
	public static Selected selected;
	public List<Transform> selectedUnit;
	// Use this for initialization
	void Start () {
		selected = this;
		selectedUnit = new List<Transform> ();
	}

	public void setGameObject(){
		selectedUnit.Clear ();
		UIPanelManager.Panel.factoryView();
	}

	public void setGameObject(Transform unit){
		selectedUnit.Clear ();
		selectedUnit.Add(unit);
		if (unit.GetComponent<Factory> ()!=null) {
			if(unit.GetComponent<Factory> ().player==this.player){
				UIPanelManager.Panel.slotsView(unit.gameObject);
			}
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
		if (selectedUnit.Count > 0) {
			if ((selectedUnit [i].GetComponent<Unit> () != null) && (selectedUnit [i].GetComponent<Seeker> () != null)) {
				return true;
			}else {
				return false;
			}
		}else {
			return false;
		}
	}

	public Transform getFactory(){
		if (selectedUnit.Count == 1) {
			if(selectedUnit[0].GetComponent<Factory> ()!=null){
				return selectedUnit[0];
			}
		}
		return null;
	}
	public void removeFromSelected(Transform Unit){
		if(selectedUnit.Contains(Unit)){
			selectedUnit.Remove (Unit);
		}
	}
	public void setPlayer(int player){
		this.player = player;
	}


}
