using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPartSelection : MonoBehaviour {
	float menuHeight;
	public static UIPartSelection UIPS;
	public int selectedPartPosition;
	// Use this for initialization
	void Start () {
		UIPS = this;

		int count=0;
		float buttonHeight=0;
		foreach (Transform child in transform) {
			count++;
			buttonHeight=child.GetComponent<LayoutElement>().minHeight;

		}
		float menuHeight = (count * buttonHeight)+20;
		GetComponent<RectTransform> ().sizeDelta = new Vector3 (200, menuHeight);
		hide ();
	}

	public void hide(){
		//GetComponent<RectTransform> ().sizeDelta = new Vector3 (0, menuHeight);
		this.gameObject.SetActive (false);
	}

	public void Show(Vector3 position){
		this.gameObject.SetActive (true);
		GetComponent<RectTransform> ().position = new Vector3 (position.x,position.y+30);
	}
}
