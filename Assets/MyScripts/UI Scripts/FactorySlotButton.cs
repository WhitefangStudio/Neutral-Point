using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FactorySlotButton : MonoBehaviour,IPointerClickHandler {
	int pos;
	int menuLevel;
	Text info;
	Image img;
	
	
	void Start(){
		info = transform.GetChild (0).GetChild (0).GetComponent<Text>();
		img = transform.GetChild (1).GetComponent <Image>();
		menuLevel = 0;
	}
	
	/*
	 * Sets the buttons info text to a passed string
	 * Disables button, if info string is null.
	 */
	public void setInfo(string infoString){
		if (infoString != null||infoString!="") {
			GetComponent<Button>().interactable=true;
			info.text = infoString;
		}
		if (infoString == null||infoString=="") {
			info.text="";
			GetComponent<Button>().interactable=false;
		}
	}

	public bool getInteractable(){
		return GetComponent<Button>().IsInteractable();
	}
	public void setImage(Image image){
		img = image;
	}
	public void setMenuLevel(int level){
		menuLevel = level;
	}

	public void setPos(int buttonPosition){
		this.pos = buttonPosition;
	}
	
	public void OnPointerClick(PointerEventData e){
		if (GetComponent<Button> ().interactable != false) {
			PartNavigation.PV.setMenuLevel (menuLevel, pos);
			if(menuLevel<2)
				menuLevel++;
		}
	}
}