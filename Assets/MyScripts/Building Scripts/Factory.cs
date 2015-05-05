using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour {
	bool selected=false;
	public int player;
	public int position;

	GameObject[] slots;

	// Use this for initialization

	void Start(){
		player =PhotonNetwork.player.ID;

	}
	void OnEnable(){
		slots = new GameObject[7];
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
	public void setPosition(string part,int pos){
		Debug.Log (part);
		
		slots [pos] = PhotonNetwork.Instantiate (part, transform.GetChild (pos).position, Quaternion.identity, 0);
		slots [pos].transform.SetParent (this.transform.GetChild(pos));


	}
}
