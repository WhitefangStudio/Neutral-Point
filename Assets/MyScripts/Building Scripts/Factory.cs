using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour {
	bool selected=false;
	public int player;
	public int position;
	Transform spawnWaypoint;

	GameObject[] slots;
	GameObject Body;
	GameObject Shield;
	GameObject Armor;

	string bodyName;
	string[] slotNames;


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
		name ="Modules/"+name.Replace("(Clone)", "");
		Debug.Log (name);
		if (Body != null) {
			if (slots [pos] == null) {
				slots [pos] = PhotonNetwork.Instantiate (name, Body.transform.GetChild (pos).position, Quaternion.identity, 0);
				slots [pos].transform.SetParent (Body.transform.GetChild (pos));
				slotNames[pos]= "Parts/"+part.GetComponent<FactoryPart>().correspondingAttachment.ToString();
				slotNames[pos]=slotNames[pos].Replace(" (UnityEngine.GameObject)","");
			}
		}
	}
	public void setBody(GameObject part){
		string name = part.name;
		name ="Modules/"+name.Replace("(Clone)", "");
		if (Body == null) {
			Body = PhotonNetwork.Instantiate (name, transform.GetChild (0).position, transform.rotation, 0);
			Body.transform.SetParent (this.transform.GetChild (0));
			slots = new GameObject[Body.transform.childCount];
			slotNames = new string[slots.Length];
			BluePrintUI.BPUI.FindActiveSlots ();
			bodyName = "Parts/"+Body.GetComponent<FactoryPart>().correspondingAttachment.ToString();
			bodyName =bodyName.Replace(" (UnityEngine.GameObject)","");
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

	public void spawnBot(){
		Vector3 spawnPos = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z + 1);
		if (bodyName == null ) {
			ShowErrorMessage.SEM.displayError ("Unit is Missing Essential Components");
		} else {
			GameObject Unit;
			Unit = PhotonNetwork.Instantiate(bodyName,spawnPos,Quaternion.identity,0);
			Unit.GetComponent<AIPatherNew>().newPath(new Vector3(transform.position.x,transform.position.y,transform.position.z-30));
			for(int i =0; i <slotNames.Length;i++){
				if(slotNames[i]!=null){
					if(Unit.GetComponent<Weapon>()!=null){
						Unit.GetComponent<Weapon>().AddPart(slotNames[i],i);
					}
				}
			}
		}
	}

}
