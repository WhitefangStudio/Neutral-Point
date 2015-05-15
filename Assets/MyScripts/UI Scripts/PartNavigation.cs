using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartNavigation : MonoBehaviour {
	
	public static PartNavigation PV;
	
	//Enumerations for sorting slot packages.
	public enum mode{editing=1,displaying=2};
	public enum WeapType{smallArms=0,largeArms=1,artillery=2};
	public enum SlotType{Weapon=0,Toggle=1,Construct=2};
	public enum BaseType{Body=0,Armour=1,Shields=2,Slot=3,Nothing=-1};
	public enum BodyType{Car=0,Tank=1,Flyer=2};

	string[][]Rank1Names;
	string[][][] Rank2Names;

	//string[] slotSubCategoryNames;
	
	//decides which menulevel to display
	public int menuLevel;
	//which slot of the factory is currently being edited?
	public int slotPosition;
	public BaseType baseType;

	//holds history of button clicks. Helpful for going back through menu levels.
	public int[] positionHistory;
	//timer to match up animations
	float timer;
	//array of all button scripts(for displaying info on the button)
	public FactorySlotButton[] FSB;
	
	// Use this for initialization
	void Start () {
		if (PV == null) {
			PV = this;
		}
		setNames ();
		
		positionHistory = new int[4];
		
		menuLevel = 0;

		//temp. tests using Slot 1 of factory only;
		slotPosition = 0;
		baseType = BaseType.Slot;
		
		FSB = new FactorySlotButton[6];
		for(int i =0;i<6;i++){
			if(i<3){
				FSB[i]=transform.GetChild(0).GetChild(i).GetComponent<FactorySlotButton>();
				FSB[i].setPos(i);
			}else{
				FSB[i]=transform.GetChild(1).GetChild(i-3).GetComponent<FactorySlotButton>();
				FSB[i].setPos(i);
			}
		}
	}

	//to be called from the BluePrintUI script.
	public void setSlotPosition(int pos){
		this.slotPosition = pos;
	}
	

	void OnEnable(){
		timer = .9f;
		menuLevel = 0;
		baseType = BaseType.Nothing;
		if (FSB != null) {
			for (int i =0; i<FSB.Length; i++) {
				FSB [i].setMenuLevel (menuLevel);
			}
		}
	}
	
	public void setMenuLevel(int menuLevel, int newPosition){

			if (menuLevel < 2) {
				//Shutter.shutter.toggleShutterAnim();
				TriangleUI.TUI.PFM.hidePanel ();
				positionHistory [menuLevel] = newPosition;
				timer = .9f;
				for (int i =0; i<6; i++) {
					FSB [i].setMenuLevel (menuLevel + 1);
				}
				this.menuLevel = menuLevel + 1;
			}else if(menuLevel == 2) {
				if(PartList.PL.partsSorted[(int)baseType] [positionHistory [menuLevel - 2]]
			   	[positionHistory [menuLevel - 1]][positionHistory [menuLevel]].GetComponent<FactoryPart> ().hasPair()){
					
					positionHistory [menuLevel] = newPosition;
					timer = .9f;
					for (int i =0; i<6; i++) {
						FSB [i].setMenuLevel (menuLevel + 1);
					}
					this.menuLevel = menuLevel + 1;
					TriangleUI.TUI.PFM.showPanel ();

					TriangleUI.TUI.setInfo ((PartList.PL.partsSorted[(int)baseType] [positionHistory [menuLevel - 2]]
				    	[positionHistory [menuLevel - 1]][positionHistory [menuLevel]]), slotPosition);

				}else{
					if(baseType== BaseType.Body){
						Selected.selected.getFactory().GetComponent<Factory>().setBody
						(PartList.PL.partsSorted[(int)baseType] [positionHistory [menuLevel - 2]]
						 [positionHistory [menuLevel - 1]][positionHistory [menuLevel]]);
						setMenuLevel (0);
						baseType = BaseType.Nothing;
					}else if(baseType == BaseType.Slot){
						Selected.selected.getFactory().GetComponent<Factory>().setPosition
							(PartList.PL.partsSorted[(int)baseType] [positionHistory [menuLevel - 2]]
							 [positionHistory [menuLevel - 1]][positionHistory [menuLevel]], slotPosition);
						setMenuLevel (0);
						baseType = BaseType.Nothing;
					}
				
				}
			}
			if (menuLevel == 3) {
			TriangleUI.TUI.PFM.hidePanel ();
				if(baseType==BaseType.Body){
					Selected.selected.getFactory ().GetComponent<Factory> ().setBody (
						PartList.PL.partsSorted[(int)baseType] [positionHistory [menuLevel - 2]]
					     [positionHistory [menuLevel - 1]][positionHistory [menuLevel]]);

					setMenuLevel (0);

				}else if(baseType==BaseType.Slot){
					Selected.selected.getFactory ().GetComponent<Factory> ().setPosition (
						PartList.PL.partsSorted[(int)baseType] [positionHistory [menuLevel - 2]]
						[positionHistory [menuLevel - 1]][positionHistory [menuLevel]], slotPosition);
					
					setMenuLevel (0);
					
				}
			}

		
		
	}
	
	public void setMenuLevel(int menuLevel){
		TriangleUI.TUI.PFM.hidePanel();
		this.menuLevel = menuLevel;
		timer = .9f;
		for (int i =0; i<6; i++) {
			FSB [i].setMenuLevel (menuLevel);
		}
		
	}

	public void backMenuLevel(){
		if (menuLevel > 0) {
			menuLevel--;
			setMenuLevel (menuLevel);
		}
		TriangleUI.TUI.PFM.hidePanel ();
		this.menuLevel = menuLevel;
		timer = .9f;
		for (int i =0; i<6; i++) {
			FSB [i].setMenuLevel (menuLevel);
		}

	}
	// Update is called once per frame
	void Update () {
		if (menuLevel < 0) {
			menuLevel = 0;
		}

		getKey ();

		if(timer<1){
			timer+=Time.deltaTime*5;
		}
		if (timer > 1 && timer < 1.5f) {
			timer += Time.deltaTime * 5;
			for (int i=0; i<6; i++) {
				FSB [i].setInfo ("");
				displayParts();
			}
		}
	}

	void displayParts(){
		if((int)baseType!=-1){
			if (menuLevel == 0) {
				for (int i=0; i<6; i++) {
					FSB [i].setMenuLevel (0);
				}
				for(int i =0;i<Rank1Names[(int)baseType].Length;i++){
				    if(Rank1Names[(int)baseType][i]!=null)
				    FSB[i].setInfo(Rank1Names[(int)baseType][i]);
				}
			}

			if (menuLevel == 1) {
				for (int i=0; i<6; i++) {
					FSB [i].setMenuLevel (1);
				}
				for(int i =0;i<Rank2Names[(int)baseType][positionHistory[menuLevel-1]].Length;i++){
					if(Rank2Names[(int)baseType][positionHistory[menuLevel-1]][i]!=null)
						FSB[i].setInfo(Rank2Names[(int)baseType][positionHistory[menuLevel-1]][i]);
				}
			}

			if (menuLevel == 2) {
				if ((int)baseType!=-1) {
					for (int i=0; i<PartList.PL.partsSorted[(int)baseType][positionHistory[menuLevel-2]][positionHistory[menuLevel-1]].Length; i++) {
						if (PartList.PL.partsSorted[(int)baseType][positionHistory[menuLevel-2]][positionHistory[menuLevel-1]] != null) {
							if (PartList.PL.partsSorted[(int)baseType][positionHistory[menuLevel-2]][positionHistory[menuLevel-1]][i] != null) {
								FSB [i].setMenuLevel (2);
								//sets button info to Weapons[last menu level][i];
								if(PartList.PL.partsSorted [(int)baseType][positionHistory [menuLevel-2]][positionHistory [menuLevel-1]] [i].GetComponent<FactoryPart> ()!=null)
									FSB [i].setInfo (PartList.PL.partsSorted [(int)baseType][positionHistory [menuLevel-2]][positionHistory [menuLevel-1]] [i].GetComponent<FactoryPart> ().getName ());

							}
						}
					}
				}
			}
			if(menuLevel==3){
				if ((int)baseType!=-1) {
					FSB [0].setInfo (PartList.PL.partsSorted [(int)baseType][positionHistory [menuLevel-3]][positionHistory [menuLevel-2]] [0].GetComponent<Slot_Weapon> ().getStrength ());
					for (int i=0; i<PartList.PL.partsSorted[(int)baseType][positionHistory[menuLevel-3]][positionHistory[menuLevel-2]][0].GetComponent<Slot_Weapon>().pair.Count; i++) {
						FSB [i].setMenuLevel (3);
								//sets button info to Weapons[last menu level][i];
						if(PartList.PL.partsSorted [(int)baseType][positionHistory [menuLevel-3]][positionHistory [menuLevel-2]] [0].GetComponent<FactoryPart> ()!=null)
							if(PartList.PL.partsSorted[(int)baseType][positionHistory[menuLevel-3]][positionHistory[menuLevel-2]][0].GetComponent<FactoryPart>().hasPair()){
								FSB [i+1].setInfo (PartList.PL.partsSorted [(int)baseType][positionHistory [menuLevel-3]][positionHistory [menuLevel-2]] [0].GetComponent<Slot_Weapon> ().pair[i].GetComponent<Slot_Weapon>().getStrength());
						}
								
					}
				}
			}
		}
	}
			
	public void setBaseType(BaseType baseType){
		this.baseType = baseType;
	}

	void setNames(){
		Rank1Names = new string[4][];
		Rank2Names = new string[4][][];
		for (int i =0; i<4; i++) {
			Rank2Names[i]= new string[6][];
		}
		Rank1Names[0]=new string[] {"Car","Tank","Flier"};
		Rank1Names[1]=new string[] {"Light","Medium","Heavy"};
		Rank1Names[2]=new string[] {"Blinking","Endurance","Regenerating"};
		Rank1Names[3]=new string[] {"Weapons","Toggles","Constructors"};
		//Bodies
		Rank2Names [0] [0] = new string[]{"Expensive","Cheap"};
		Rank2Names [0] [1] = new string[]{"Expensive","Cheap"};//tanks
		Rank2Names [0] [2] = new string[]{"Expensive","Cheap"};//Fliers
		//Armor
		Rank2Names [1] [0] = new string[6];//Light
		Rank2Names [1] [1] = new string[6];//Medium
		Rank2Names [1] [2] = new string[6];//Heavy
		//Shields
		Rank2Names [2] [0] = new string[6];//Blinking
		Rank2Names [2] [1] = new string[6];//Endurance
		Rank2Names [2] [2] = new string[6];//Regenrative
		//Slots
		Rank2Names [3] [0] = new string[]{"Small Arms","Large Arms","Artillery"};
		Rank2Names [3] [1] = new string[]{"Toggle_Category","Toggle_Category2"};//Toggles
		Rank2Names [3] [2] = new string[]{"Construct_Category","Construct_Category2"};//Constructors

	}
	void getKey(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if(FSB[0].getInteractable())
				setMenuLevel(menuLevel,0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			if(FSB[1].getInteractable())
				setMenuLevel(menuLevel,1);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			if(FSB[2].getInteractable())
				setMenuLevel(menuLevel,2);
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			if(FSB[3].getInteractable())
				setMenuLevel(menuLevel,3);
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			if(FSB[4].getInteractable())
				setMenuLevel(menuLevel,4);
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			if(FSB[5].getInteractable())
				setMenuLevel(menuLevel,5);
		}

	}

}
