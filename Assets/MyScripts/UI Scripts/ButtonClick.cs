using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour,IPointerDownHandler,IPointerClickHandler {
	public int position;
	public bool isFactoryButton;
	public bool isSlotButton;
	public bool isPartButton;

	bool showingPartMenu;
	void start(){
	}
	public void OnPointerDown(PointerEventData e){
		PlayUISounds.Sounds.click ();

	}
	public void OnPointerClick(PointerEventData e){
		if(isFactoryButton==true){
			GameObject.Find ("Score(Clone)").GetComponent<SpawnFactory>().place(position);
		}
		if (isSlotButton == true) {
			if(!UIPartSelection.UIPS.gameObject.activeInHierarchy){
				UIPartSelection.UIPS.Show (GetComponent<RectTransform>().position);
				UIPartSelection.UIPS.selectedPartPosition=position;
			}else{
				UIPartSelection.UIPS.hide();
			}
		}
		if (isPartButton == true) {
			FactoryButtons.FB.slot (position,UIPartSelection.UIPS.selectedPartPosition);
		}
	}

}