using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BluePrintButton : MonoBehaviour,IPointerClickHandler {
	int position;
	BluePrintUI holder;
	bool isChosen;
	public bool shouldChangeColor;
	Button button;

	// Use this for initialization
	public void OnPointerClick(PointerEventData e){
		holder.buttonClicked (position);
	}

	public void setPosition(int pos){
		this.position = pos;
	}

	public void setChosen(bool isChosen){
		if (shouldChangeColor) {
			if(button!=null){
			this.isChosen = isChosen;
				if (isChosen) {
					holder.selectedButton(position);
					ColorBlock tempColor = button.colors;
					tempColor.normalColor = Color.blue;
					tempColor.highlightedColor = Color.blue;
					button.colors = tempColor;
				} else {
					ColorBlock tempColor = button.colors;
					tempColor.normalColor = Color.white;
					tempColor.highlightedColor = Color.white;
					button.colors = tempColor;
				}
			}
		}
	}
	void Start () {
		button = GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (holder == null) {
			holder = BluePrintUI.BPUI;
		}
	
	}
}
