using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMouseTrack : MonoBehaviour,IPointerDownHandler,IPointerClickHandler {
	public GameObject panel;
	bool open = false;
	float timer;
	Camera cam;
	public void OnPointerDown(PointerEventData e){
		panel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, 0);
		open = false;
	}


	void Start(){
		panel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, 0);

	}
	public void OnPointerClick(PointerEventData e){
		RaycastHit hit;
		Physics.Raycast	(cam.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity);
		if (e.button == PointerEventData.InputButton.Right) {
			Debug.Log (hit.collider.ToString());
			if(string.Equals(hit.collider.ToString(),"Factory(Clone) (UnityEngine.BoxCollider)")){
				panel.transform.position=e.position;
				open=true;
				timer=0;
			}
		}
		if (e.button == PointerEventData.InputButton.Left) {
			if(string.Equals(hit.collider.ToString(),"Factory(Clone) (UnityEngine.BoxCollider)")){
				UIPanelManager.Panel.slotsView (hit.collider.gameObject);
			}else{
				UIPanelManager.Panel.factoryView();
			}
		}
		UIPartSelection.UIPS.hide ();
	}
	void Update(){
		if(cam==null){
			if(GameObject.Find ("Main Camera(Clone)")!=null){
				if (GameObject.Find ("Main Camera(Clone)").GetComponent<Camera>() != null) {
					cam = GameObject.Find ("Main Camera(Clone)").GetComponent<Camera>();
				}
			}
		}
		timer += Time.deltaTime;
		if (open == true) {
			panel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (100* Mathf.Lerp (0, 1, timer * 2), 200 * Mathf.Lerp (0, 1, timer * 2));
		} else {
			panel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, 0);
		}
	}
}
