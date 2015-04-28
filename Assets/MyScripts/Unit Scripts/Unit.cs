using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	public bool selected = false;
	public bool selected2=false;
	public bool hovered = false;
	public int player = 0;
	Renderer ren;
	
	// Use this for initialization
	void Start () {
		ren = (Renderer)GetComponentInChildren<MeshRenderer>();

		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetMouseButtonUp (0)){
			if(Input.mousePosition.y>190){
				if ((Mathf.Abs (Camera_UnitSelect.selection.width) >2) && (Mathf.Abs (Camera_UnitSelect.selection.height)>2)){
					Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
					camPos.y= Camera_UnitSelect.InvertMouseY(camPos.y);
					selected = Camera_UnitSelect.selection.Contains(camPos);
				}else{
					selected =false;
					selected = selected2;
					selected2 =false;
				}
			}
			
			/*if (selected==true){
				GetComponentInChildren<Camera>().enabled= true;
				} else{
				GetComponentInChildren<Camera>().enabled= false;
			}*/
		}
		if (Input.GetMouseButtonUp (0)) {
			if ((Input.mousePosition.y>190)) {
				if ((Mathf.Abs (Camera_UnitSelect.selection.width) > 2) && (Mathf.Abs (Camera_UnitSelect.selection.height) > 2) && Input.mousePosition.y > 190) {
					Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);
					camPos.y = Camera_UnitSelect.InvertMouseY (camPos.y);
					hovered = Camera_UnitSelect.selection.Contains (camPos);
				} else {
					hovered = false;
				}
			}
		}
		if (selected){
			
			ren.material.color = new Color(.9f,.1f,.1f,.8f);
		}else if (hovered){
			ren.material.color = new Color (.5f,.3f,.3f,.3f);
		} else{
			ren.material.color = Color.grey;
		}
		
	}
	
	void OnMouseUpAsButton(){
		Debug.Log ("clicked");
		selected2 = true;
	}
}