using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour,IPointerDownHandler,IPointerClickHandler {
	/*
	 * Placed on UI Buttons, and plays the click sound when clicked
	 * 
	 */
	public void OnPointerDown(PointerEventData e){
		if (GetComponent<Button> ().interactable==true) {
			PlayUISounds.Sounds.click ();
			Debug.Log ("clicked");
		}
	
	}
	public void OnPointerClick(PointerEventData e){

	}

}