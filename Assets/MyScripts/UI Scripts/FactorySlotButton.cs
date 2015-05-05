using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FactorySlotButton : MonoBehaviour,IPointerClickHandler {
	public PartNavigation.WeapType position;
	public int pos;
	public int menuLevel;
	Text info;
	Image img;


	void Start(){
		info = transform.GetChild (0).GetChild (0).GetComponent<Text>();
		img = transform.GetChild (1).GetComponent <Image>();
		menuLevel = 0;
	}
	

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
	public void setImage(Image image){
		img = image;
	}
	public void setMenuLevel(int level){
		menuLevel = level;
	}

	public void OnPointerClick(PointerEventData e){
		if (GetComponent<Button> ().interactable != false) {
			PartNavigation.PV.setMenuLevel (menuLevel, position, pos);
			if (menuLevel == 0) {
				menuLevel = 1;
			}
		}
	}
}
