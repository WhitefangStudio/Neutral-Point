using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CheckForClick : MonoBehaviour,IPointerDownHandler{

	public void OnPointerDown(PointerEventData e){
		if (e.button==PointerEventData.InputButton.Left) {
			Selected.selected.setGameObject ();
		}
	}
}
