using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartNavigation : MonoBehaviour {

	public static PartNavigation PV;

	public enum WeapType{smallArms,largeArms,artillery};
	public string[] levelOne;
	List<GameObject> smallArms;
	List<GameObject> largeArms;
	List<GameObject> artillery;

	public GameObject[] slots;
	int menuLevel;

	int slotPosition;
	WeapType position;
	float timer;
	FactorySlotButton[] FSB;

	// Use this for initialization
	void Start () {
		if (PV == null) {
			PV = this;
		}

		smallArms = new List<GameObject>();
		largeArms = new List<GameObject>();
		artillery = new List<GameObject>();

		menuLevel = 0;
		slotPosition = 0;

		FSB = new FactorySlotButton[6];
		for(int i =0;i<6;i++){
			if(i<3){
				FSB[i]=transform.GetChild(0).GetChild(i).GetComponent<FactorySlotButton>();
			}else{
				FSB[i]=transform.GetChild(1).GetChild(i-3).GetComponent<FactorySlotButton>();
			}
		}
		sortWeapons();
	}

	void sortWeapons(){
		for (int i = 0; i<slots.Length; i++) {
			if(slots[i].GetComponent<SlotInfoPackage>().getWeaponType()==WeapType.smallArms){
				smallArms.Add (slots[i]);
			}
			if(slots[i].GetComponent<SlotInfoPackage>().getWeaponType()==WeapType.largeArms){
				largeArms.Add (slots[i]);
			}
			if(slots[i].GetComponent<SlotInfoPackage>().getWeaponType()==WeapType.smallArms){
				artillery.Add (slots[i]);
			}
			slots[i]=null;
			
		}
	}

	void OnEnable(){
		menuLevel = 0;
		if (FSB != null) {
			for (int i =0; i<FSB.Length; i++) {
				FSB [i].setMenuLevel (menuLevel);
			}
		}
	}

	public void setMenuLevel(int menuLevel,WeapType position, int pos){
		if (menuLevel == 0) {
			Shutter.shutter.toggleShutterAnim();
			TriangleUI.TUI.PFM.hidePanel ();
			this.position = position;
			timer = 0;
			for (int i =0; i<6; i++) {
				FSB [i].setMenuLevel (menuLevel+1);
			}
		}
		if (menuLevel == 1) {
			TriangleUI.TUI.PFM.showPanel();
			if(this.position==WeapType.smallArms){
				TriangleUI.TUI.setInfo(smallArms[pos],slotPosition);
			}
			if(this.position==WeapType.largeArms){
				TriangleUI.TUI.setInfo(largeArms[pos],slotPosition);
			}
			if(this.position==WeapType.artillery){
				TriangleUI.TUI.setInfo(artillery[pos],slotPosition);
			}
			
		}
		this.menuLevel = menuLevel+1;
	
	}

	public void setMenuLevel(int menuLevel){
		TriangleUI.TUI.PFM.hidePanel();
		this.menuLevel = menuLevel;
		timer = 0;
		for (int i =0; i<6; i++) {
			FSB [i].setMenuLevel (menuLevel);
		}
		
	}

	// Update is called once per frame
	void Update () {
		if (menuLevel < 0) {
			menuLevel = 0;
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			if(menuLevel>0){
				menuLevel--;
				setMenuLevel (menuLevel);
				Shutter.shutter.toggleShutterAnim ();
			}
		}
		change ();

	}
	void change(){
		if(timer<1){
			timer+=Time.deltaTime*5;
		}
		if(timer>1){
			for (int i=0; i<6; i++) {
				FSB [i].setInfo("");
			}

			if (menuLevel == 0) {
				for (int i=0; i<6; i++) {
					FSB [i].setMenuLevel (0);
					FSB [i].setInfo (levelOne [i]);
				}
			}
			if (menuLevel == 1&&position==WeapType.smallArms) {
				for (int i=0; i<smallArms.Count; i++) {
					FSB [i].setInfo (smallArms [i].GetComponent<SlotInfoPackage>().name);
				}
			}
			if (menuLevel == 1&&position==WeapType.largeArms) {
				for (int i=0; i<largeArms.Count; i++) {
					FSB [i].setInfo (largeArms [i].GetComponent<SlotInfoPackage>().name);
				}
			}
			if (menuLevel == 1&&position==WeapType.artillery) {
				for (int i=0; i<artillery.Count; i++) {
					FSB [i].setInfo (artillery [i].GetComponent<SlotInfoPackage>().name);
				}
			}
		}
	}
}
