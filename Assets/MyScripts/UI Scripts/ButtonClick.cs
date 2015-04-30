using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour,IPointerDownHandler,IPointerClickHandler {

	public void OnPointerDown(PointerEventData e){
		PlayUISounds.Sounds.click ();
		Debug.Log ("clicked");

	}
	public void OnPointerClick(PointerEventData e){

	}

}