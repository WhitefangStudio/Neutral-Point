using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CheckForClick : MonoBehaviour,IPointerDownHandler{

	/*
	 * This script is placed on a Panel which covers the entire screen.
	 * It checks for a left click anywhere that is not part of the bottom UI Bar and sets the current selection to null
	 */ 
	private Camera cam = null;
	
	
	// Use this for initialization
	void Update () {
		if (cam == null) {
			if (GameObject.Find ("Main Camera(Clone)") != null) {
				cam = GameObject.Find ("Main Camera(Clone)").GetComponent<Camera> ();
			}
		}
	}
	public void OnPointerDown(PointerEventData e){
		if (e.button==PointerEventData.InputButton.Left) {
			RaycastHit hit;
			if (Physics.Raycast	(cam.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity)) {
				if(hit.collider.tag!="Factory"){
					Debug.Log("click");
					Selected.selected.setGameObject ();
					TriangleUI.TUI.PFM.hidePanel();
					BluePrintUI.BPUI.buttonClicked(-1);
				}
			}

		}
	}
}
