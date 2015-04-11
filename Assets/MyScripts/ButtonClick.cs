using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour,IPointerDownHandler,IPointerClickHandler {
	public int position;
	public bool isFactoryButton;

	public void OnPointerDown(PointerEventData e){
		PlayUISounds.Sounds.click ();

	}
	public void OnPointerClick(PointerEventData e){
		if(isFactoryButton==true){
			GameObject.Find ("Score(Clone)").GetComponent<SpawnFactory>().place(position);
		}
	}

}