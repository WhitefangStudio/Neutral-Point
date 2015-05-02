using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour,IPointerDownHandler,IPointerClickHandler {

	public void OnPointerDown(PointerEventData e){
		if (GetComponent<Button> ().interactable==true) {
			PlayUISounds.Sounds.click ();
			Debug.Log ("clicked");
		}

	}
	public void OnPointerClick(PointerEventData e){

	}

}