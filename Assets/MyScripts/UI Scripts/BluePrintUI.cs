using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public enum keyPush{
	Q,W,E,R,A,S,D,F,Z,X,C
}
public static class Extension{
	
}

public class BluePrintUI : MonoBehaviour {
	public static BluePrintUI BPUI;

	public Button[] BlueprintButtons;

	int selected;

	delegate void BlueprintButton();
	BlueprintButton[] buttons;

	// Use this for initialization
	void Start () {
		selected = -1;
		if (BPUI == null) {
			BPUI = this;
		}

		for (int i =0; i<BlueprintButtons.Length; i++) {
			BlueprintButtons[i].GetComponent<BluePrintButton>().setPosition(i);
		}

		buttons = new BlueprintButton[11];
		buttons [0] = new BlueprintButton (A);
		buttons [1] = new BlueprintButton (S);
		buttons [2] = new BlueprintButton (D);
		buttons [3] = new BlueprintButton (Q);
		buttons [4] = new BlueprintButton (W);
		buttons [5] = new BlueprintButton (E);
		buttons [6] = new BlueprintButton (R);
		buttons [7] = new BlueprintButton (F);
		buttons [8] = new BlueprintButton (Z);
		buttons [9] = new BlueprintButton (X);
		buttons [10] = new BlueprintButton (C);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			if (getKeyCode () != -1) {
				buttonClicked (getKeyCode ());
			}
		}
	}

	void OnEnable(){
		selected = -1;
		buttonClicked (-1);
		FindActiveSlots ();
	}

	public void selectedButton(int position){
		this.selected = position;
	}

	public void buttonClicked(int position){
		if (position >= 0) {
			if (BlueprintButtons [position].transform.GetComponent<BluePrintButton> ().shouldChangeColor) {
				for (int i=0; i<BlueprintButtons.Length; i++) {
					BlueprintButtons [i].transform.GetComponent<BluePrintButton> ().setChosen (false);
				}
				BlueprintButtons [position].transform.GetComponent<BluePrintButton> ().setChosen (true);

			}
			buttons [position] ();
		} else {
			for (int i=0; i<BlueprintButtons.Length; i++) {
				BlueprintButtons [i].transform.GetComponent<BluePrintButton> ().setChosen (false);
			}
		}
	}

	public void FindActiveSlots(){
		if (Selected.selected != null) {
			for (int i =0; i <BlueprintButtons.Length; i++) {
				BlueprintButtons [i].interactable = true;
			}
			if (Selected.selected.getFactory () != null) {
				int activeSlots = Selected.selected.getFactory ().GetComponent<Factory> ().getOpenSlots ();
				if (activeSlots == -1) {
					for (int i =1; i<8; i++) {
						BlueprintButtons [i].interactable = false;
					}
				} else {
					for (int i=activeSlots+3; i<8; i++) {
						BlueprintButtons [i].interactable = false;
					}
				}
			}
		}
	}

	public int getKeyCode(){
	if (Input.GetKeyDown(KeyCode.Q)) 
		return 3;
	if (Input.GetKeyDown(KeyCode.W)) 
		return 4;
	if (Input.GetKeyDown(KeyCode.E)) 
		return 5;
	if (Input.GetKeyDown(KeyCode.R)) 
		return 6;
	if (Input.GetKeyDown(KeyCode.A)) 
		return 0;
	if (Input.GetKeyDown(KeyCode.S)) 
		return 1;
	if (Input.GetKeyDown(KeyCode.D)) 
		return 2;
	if (Input.GetKeyDown(KeyCode.F)) 
		return 7;
	if (Input.GetKeyDown(KeyCode.Z)) 
		return 8;
	if (Input.GetKeyDown(KeyCode.X)) 
		return 9;
	if (Input.GetKeyDown(KeyCode.C)) 
		return 10;
	
	return -1;

}
	
	void Q(){
		PartNavigation.PV.setMenuLevel (0);
		PartNavigation.PV.setBaseType (PartNavigation.BaseType.Slot);
		PartNavigation.PV.setSlotPosition (0);
	}
	void W(){
		PartNavigation.PV.setMenuLevel (0);
		PartNavigation.PV.setBaseType (PartNavigation.BaseType.Slot);
		PartNavigation.PV.setSlotPosition (1);
	}
	void E(){
		PartNavigation.PV.setMenuLevel (0);
		PartNavigation.PV.setBaseType (PartNavigation.BaseType.Slot);
		PartNavigation.PV.setSlotPosition (2);
	}
	void R(){
		PartNavigation.PV.setMenuLevel (0);
		PartNavigation.PV.setBaseType (PartNavigation.BaseType.Slot);
		PartNavigation.PV.setSlotPosition (3);
		//PartNavigation.PV.setSlotPosition (0);
	}
	void A(){
		PartNavigation.PV.setMenuLevel (0);
		PartNavigation.PV.setBaseType (PartNavigation.BaseType.Body);
	}
	void S(){
		PartNavigation.PV.setMenuLevel (0);
		PartNavigation.PV.setBaseType (PartNavigation.BaseType.Shields);
	}
	void D(){
		PartNavigation.PV.setMenuLevel (0);
		PartNavigation.PV.setBaseType (PartNavigation.BaseType.Armour);
	}
	void F(){
		PartNavigation.PV.setMenuLevel (0);
		PartNavigation.PV.setBaseType (PartNavigation.BaseType.Slot);
		PartNavigation.PV.setSlotPosition (4);

	}
	void Z(){

	}
	void X(){
		if(selected!=-1){
			if (Selected.selected.getFactory() != null) {
				Selected.selected.getFactory().GetComponent<Factory>().clearPart(selected);
			}
		}
	}
	void C(){
		if (PartNavigation.PV!=null)
			PartNavigation.PV.backMenuLevel ();
	}
}
