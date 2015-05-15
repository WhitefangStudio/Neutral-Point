using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpawnFactoryButton : MonoBehaviour ,IPointerClickHandler{
	public int factNum;
	SpawnFactory sf;
	// Use this for initialization
	void Start () {
		sf = GameObject.Find ("_Scripts").GetComponent<SpawnFactory> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerClick(PointerEventData e){
		if (sf.getFactory (factNum) == null) {
			sf.place (factNum);
		} else {
			Selected.selected.setGameObject(sf.getFactory(factNum).transform);
		}

	}
}
