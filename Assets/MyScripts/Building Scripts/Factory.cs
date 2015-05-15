using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour {
	bool selected=false;
	public int player;
	public int position;

	GameObject[] slots;
	GameObject Body;
	GameObject Shield;
	GameObject Armor;


	// Use this for initialization

	void Start(){
		player =PhotonNetwork.player.ID;

	}
	void OnEnable(){
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
		if (Body != null) {
			if (slots [pos] == null) {
				slots [pos] = PhotonNetwork.Instantiate (part, transform.GetChild (pos).position, Quaternion.identity, 0);
				slots [pos].transform.SetParent (Body.transform.GetChild (pos));
			}
		}
	}

	public void setPosition(GameObject part,int pos){
		string name = part.name;
		name ="Parts/"+name.Replace("(Clone)", "");
		Debug.Log (name);
		if (Body != null) {
			if (slots [pos] == null) {
				slots [pos] = PhotonNetwork.Instantiate (name, Body.transform.GetChild (pos).position, Quaternion.identity, 0);
				slots [pos].transform.SetParent (Body.transform.GetChild (pos));
			}
		}
	}
	public void setBody(GameObject part){
		string name = part.name;
		name ="Parts/"+name.Replace("(Clone)", "");
		if (Body == null) {
			Body = PhotonNetwork.Instantiate (name, transform.GetChild (0).position, transform.rotation, 0);
			Body.transform.SetParent (this.transform.GetChild (0));
			slots = new GameObject[Body.transform.childCount];
			BluePrintUI.BPUI.FindActiveSlots ();
		}
		
		
	}

	public int getOpenSlots (){
		if (slots == null) {
			return -1;
		}else{
			return slots.Length;
		}
	}

	public bool hasBody(){
		if (Body != null) {
			return true;
		} else {
			return false;
		}
	}
	public void clearPart(int position){
		PhotonNetwork.Destroy (slots [position]);
		slots [position] = null;
		BluePrintUI.BPUI.FindActiveSlots ();
	}

}
