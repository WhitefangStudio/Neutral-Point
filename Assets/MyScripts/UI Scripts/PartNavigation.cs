using UnityEngine;
using System.Collections;

public class PartNavigation : MonoBehaviour {
	public string[] levelOne;
	public string[] smallArms;
	public string[] largeArms;
	public string[] artillery;
	public int menuLevel;
	int position;
	float timer;
	public FactorySlotButton[] FSB;

	// Use this for initialization
	void Start () {
		menuLevel = 0;
		FSB = new FactorySlotButton[6];
		for(int i =0;i<6;i++){
			if(i<3){
				FSB[i]=transform.GetChild(0).GetChild(i).GetComponent<FactorySlotButton>();
			}else{
				FSB[i]=transform.GetChild(1).GetChild(i-3).GetComponent<FactorySlotButton>();
			}
		}
	}

	public void setMenuLevel(int menuLevel,int position){
		TriangleUI.TUI.PFM.hidePanel();
		this.menuLevel = menuLevel;
		this.position = position;
		timer = 0;
		for (int i =0; i<6; i++) {
			FSB [i].setMenuLevel (menuLevel);
		}
	
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
			menuLevel--;
			setMenuLevel (menuLevel);
			Shutter.shutter.toggleShutterAnim ();
		}
		change ();

	}
	void change(){
		if(timer<1){
			timer+=Time.deltaTime*5;
		}
		if(timer>1){
			if (menuLevel == 0) {
				for (int i=0; i<6; i++) {
					FSB [i].setMenuLevel (0);
					FSB [i].setInfo (levelOne [i]);
					FSB [i].setPosition(i);
				}
			}
			if (menuLevel == 1&&position==0) {
				for (int i=0; i<6; i++) {
					FSB [i].setInfo (smallArms [i]);
					FSB [i].setPosition(i);
				}
			}
			if (menuLevel == 1&&position==1) {
				for (int i=0; i<6; i++) {
					FSB [i].setInfo (largeArms [i]);
					FSB [i].setPosition(i);
				}
			}
			if (menuLevel == 1&&position==2) {
				for (int i=0; i<6; i++) {
					FSB [i].setInfo (artillery [i]);
					FSB [i].setPosition(i);
				}
			}
		}
	}
}
