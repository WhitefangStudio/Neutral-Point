using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour {
	bool selected=false;
	public int player;
	// Use this for initialization

	void Start(){
		player =PhotonNetwork.player.ID;
	}

	void OnMouseUpAsButton(){
		if (this.gameObject.activeInHierarchy) {
			Debug.Log ("clicked");
			selected = true;
			UIPanelManager.Panel.slotsView ();
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if ((Input.mousePosition.y > 190)) {
				selected = false;
				UIPanelManager.Panel.factoryView ();
			}
		}

	}
}
