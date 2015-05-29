using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpawnFactoryButton : MonoBehaviour ,IPointerClickHandler{
	public int factNum;
	SpawnFactory sf;
	Factory factory;
	// Use this for initialization
	void Start () {
		sf = GameObject.Find ("_Scripts").GetComponent<SpawnFactory> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerClick(PointerEventData e){
		if (e.button == PointerEventData.InputButton.Left) {
			if (sf.getFactory (factNum) == null) {
				sf.place (factNum);
			} else {
				Selected.selected.setGameObject (sf.getFactory (factNum).transform);
			}

		}if (e.button == PointerEventData.InputButton.Right) {
			if (sf.getFactory (factNum) != null){
				if(factory ==null){
					factory = sf.getFactory(factNum).GetComponent<Factory>();
				}
				factory.spawnBot();
			}
		}
	}
}
