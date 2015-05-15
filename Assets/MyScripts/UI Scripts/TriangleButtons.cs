using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TriangleButtons : MonoBehaviour, IPointerClickHandler{
	public int pos;
	Text name;
	GameObject part;

	public void OnPointerClick(PointerEventData e){
		if (e.button == PointerEventData.InputButton.Left) {
			Selected.selected.getFactory().GetComponent<Factory>().setPosition(part,pos);
			PartNavigation.PV.setMenuLevel (0);
		}
	}

	public void setPos(int Pos){
		this.pos = Pos;
	}

	public void setName(string name){
		if (name != null && name != "") {
			this.name.text=name;
		}
	}

	public void setObject(GameObject part){
		this.part = part;
		setName (part.GetComponent<Slot_Weapon> ().getStrength());
	}

	// Use this for initialization
	void Start () {
		name = GetComponentInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
