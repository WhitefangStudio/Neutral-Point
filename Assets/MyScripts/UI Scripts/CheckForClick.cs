using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CheckForClick : MonoBehaviour,IPointerDownHandler{

	/*
	 * This script is placed on a Panel which covers the entire screen.
	 * It checks for a left click anywhere that is not part of the bottom UI Bar and sets the current selection to null
	 */ 

	public void OnPointerDown(PointerEventData e){
		if (e.button==PointerEventData.InputButton.Left) {
			Selected.selected.setGameObject ();
			TriangleUI.TUI.PFM.hidePanel();
		}
	}
}
