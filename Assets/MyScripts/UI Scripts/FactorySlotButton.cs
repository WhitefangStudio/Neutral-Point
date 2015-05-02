using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FactorySlotButton : MonoBehaviour,IPointerClickHandler {
	public PartNavigation PV;
	PopFromSide Pop;

	int position;
	public int menuLevel;
	Text info;
	Image img;

	void Start(){
		Pop = TriangleUI.TUI.PFM;
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
			GetComponent<Button>().interactable=false;
		}
	}
	public void setImage(Image image){
		img = image;
	}
	public void setMenuLevel(int level){
		menuLevel = level;
	}
	public void setPosition(int position){
		this.position=position;
	}

	public void OnPointerClick(PointerEventData e){
		if (menuLevel == 1) {
			Pop.showPanel();
		}
		if (menuLevel == 0) {
			menuLevel = 1;
			PV.setMenuLevel (menuLevel, position);
			Shutter.shutter.toggleShutterAnim();
		}
	}
}
